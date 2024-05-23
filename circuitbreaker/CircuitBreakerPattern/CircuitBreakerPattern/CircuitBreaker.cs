using System.Net;

namespace CircuitBreakerPattern;

public class CircuitBreaker
{
    private const string StateClosed = "Closed";
    private const string StateOpen = "Open";
    private const string StateHalfOpen = "HalfOpen";

    private const string LogPrefix = nameof(CircuitBreaker);

    private string _state;
    private int _failuresCount = 0;
    private DateTime _lastSuccess;

    private static TimeSpan RecoveryDelay;
    private static int FailuresLimit;
    private static Type[] ExceptionsToHandle;


    public CircuitBreaker(TimeSpan breakDelay, int failuresLimit, Type[]? exceptions = null)
    {
        RecoveryDelay = breakDelay;
        FailuresLimit = failuresLimit;
        ExceptionsToHandle = exceptions ?? [typeof(Exception)];

        _state = StateClosed;
        _lastSuccess = DateTime.UtcNow;

        Console.WriteLine($"{LogPrefix} | Circuit Breaker initialized with RecoveryDelay: {RecoveryDelay}, FailuresLimit: {FailuresLimit}");
    }

    public Task<HttpResponseMessage> ExecuteInCircuitBreaker(Func<HttpResponseMessage> functionToExecute)
    {
        if (_state == StateClosed)
        {
            return HandleInClosedState(functionToExecute);
        }
        else if (_state == StateOpen)
        {
            return HandleInOpenState(functionToExecute);
        }

        return HandleInHalfOpenState(functionToExecute);
    }

    private void ChangeState(string newState)
    {
        var prevState = _state;
        _state = newState;
        Console.WriteLine($"{LogPrefix} | Circuit Breaker state changed from {prevState} to {_state}.");
    }

    private void Reset()
    {
        _lastSuccess = DateTime.UtcNow;
        _failuresCount = 0;
        Console.WriteLine($"{LogPrefix} | Circuit Breaker state reset.");
    }

    private Task<HttpResponseMessage> HandleInClosedState(Func<HttpResponseMessage> functionToExecute)
    {
        var logPrefix = $"{LogPrefix} | {nameof(HandleInClosedState)}";
        try
        {
            var result = functionToExecute();
            Console.WriteLine($"{logPrefix} | Successful call. Circuit Breaker state remains Closed.");
            Reset();
            return Task.FromResult(result);
        }
        catch (Exception ex) 
        {
            if (ExceptionsToHandle.Contains(ex.GetType()))
            {
                _failuresCount++;
                if (_failuresCount >= FailuresLimit)
                {
                    ChangeState(StateOpen);
                    Console.WriteLine($"{logPrefix} | Failures limit reached. Circuit Breaker state changed to Open.");
                    return HandleInOpenState(functionToExecute);
                }
            }
            return Task.FromException<HttpResponseMessage>(ex);
        }
    }

    private Task<HttpResponseMessage> HandleInOpenState(Func<HttpResponseMessage> functionToExecute)
    {
        if (DateTime.UtcNow - _lastSuccess > RecoveryDelay)
        {
            ChangeState(StateHalfOpen);
            Console.WriteLine($"{LogPrefix} | {nameof(HandleInOpenState)} | Recovery delay reached. Circuit Breaker state changed to HalfOpen.");
            return HandleInHalfOpenState(functionToExecute);
        }
        else
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
        }
    }

    private Task<HttpResponseMessage> HandleInHalfOpenState(Func<HttpResponseMessage> functionToExecute)
    {
        try
        {
            var result = functionToExecute();
            ChangeState(StateClosed);
            Console.WriteLine($"{LogPrefix} | {nameof(HandleInHalfOpenState)} | Successful call. Circuit Breaker state changed to Closed.");
            Reset();
            return Task.FromResult(result);
        }
        catch (Exception ex)
        {
            if (ExceptionsToHandle.Contains(ex.GetType()))
            {
                _failuresCount++;
                ChangeState(StateOpen);
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return Task.FromException<HttpResponseMessage>(ex);
        }
    }

}

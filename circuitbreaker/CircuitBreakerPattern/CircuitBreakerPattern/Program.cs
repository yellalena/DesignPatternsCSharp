using CircuitBreakerPattern;
using System.Net;

class CircuitBreakerMain
{
    public static void Main()
    {
        var circuitBreaker = new CircuitBreaker(TimeSpan.FromSeconds(30), 1, [typeof(HandleableException)]);

        // send successfull request

        var response = circuitBreaker.ExecuteInCircuitBreaker(() =>
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        });

        // send failed request

        response = circuitBreaker.ExecuteInCircuitBreaker(() =>
        {
            throw new HandleableException("Failed request");
        });

        // send one more failed request

        response = circuitBreaker.ExecuteInCircuitBreaker(() =>
        {
            throw new HandleableException("Failed request");
        });

        // wait for recovery delay

        Thread.Sleep(30000);

        // send successfull request

        response = circuitBreaker.ExecuteInCircuitBreaker(() =>
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        });
    }
}
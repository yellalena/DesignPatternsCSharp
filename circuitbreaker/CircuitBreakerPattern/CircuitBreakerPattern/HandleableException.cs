namespace CircuitBreakerPattern;

public class HandleableException : Exception
{
    public HandleableException() { }

    public HandleableException(string message) : base(message) { }

    public HandleableException(string message, Exception innerException) : base(message, innerException) { }
}

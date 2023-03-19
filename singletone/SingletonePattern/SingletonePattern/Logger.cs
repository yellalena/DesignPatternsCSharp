namespace SingletonPattern
{
    public class Logger
    {
        private static readonly Lazy<Logger> _loggerInstance = new(() => new Logger());
        public static Logger Instance { get { return _loggerInstance.Value; } }
        private Logger() { }
    }
}

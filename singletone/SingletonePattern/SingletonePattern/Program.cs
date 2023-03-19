using SingletonPattern;

class Singleton
{
    public static void Main()
    {
        Thread t1 = new(() =>
        {
            var logger = Logger.Instance;
            Console.WriteLine($"Thread 1, logger instance: {logger.GetHashCode()}");
        });

        Thread t2 = new(() =>
        {
            var logger = Logger.Instance;
            Console.WriteLine($"Thread 2, logger instance: {logger.GetHashCode()}");
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}
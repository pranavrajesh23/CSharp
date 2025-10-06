using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class Logger
{
    private static Logger _instance = null;
    private static readonly object _lock = new object();
    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)  // Thread-safe block
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
    }
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message} | Instance HashCode: {this.GetHashCode()}");
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Threads ===");
        Thread[] threads = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            threads[i] = new Thread(() =>
            {
                Logger.Instance.Log($"Log from Thread {Thread.CurrentThread.ManagedThreadId}");
            });
            threads[i].Start();
        }
        foreach (var thread in threads)
            thread.Join();

        Console.WriteLine("\n=== Tasks ===");
        Task[] tasks = new Task[5];
        for (int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                Logger.Instance.Log($"Log from Task {Task.CurrentId}");
            });
        }
        Task.WaitAll(tasks);
    }
}



namespace ThreadPools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine("Hello from the pool");
                //Uncaught exceptions in thread pool, workers will crash your app.
                //throw new InvalidOperationException();
            });

            ThreadPool.GetMinThreads(out int workerThreads, out _);
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out _);
            Console.WriteLine($"The thread pool has a minimum of {workerThreads} workers and a maximum of {maxWorkerThreads}");


        }
    }
}

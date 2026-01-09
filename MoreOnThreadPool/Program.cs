namespace MoreOnThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.GetMinThreads(out int workerThreads, out _);
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out _);
            Console.WriteLine($"The thread pool has a minimum of {workerThreads} workers and a maximum of {maxWorkerThreads}");


            WaitCallback worker = (object? state) => 
            {
                DateTime posted = (DateTime)state;
                TimeSpan executionGap = DateTime.Now - posted;
                string msg = $"Thread pool capacity: {ThreadPool.ThreadCount}, execution gap is {executionGap.TotalMilliseconds} ms";
                Console.WriteLine(msg);
                Thread.Sleep(200);
                
            };

            for (int i = 0; i < 1000; i++)
            {
                ThreadPool.QueueUserWorkItem(worker, DateTime.Now);
            }

            Console.ReadLine();
        }
    }
}

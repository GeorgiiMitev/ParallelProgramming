namespace Semaphores
{
    internal class Program
    {
        static Semaphore semaphore;

        static void Worker(object objParam)
        {
            string threadName = (string)objParam;
            Console.WriteLine($"{threadName} starts.");
            Thread.Sleep(500);

            Console.WriteLine($"{threadName} tries to acquire the resource.");
            semaphore.WaitOne();
            Console.WriteLine($"{threadName} successfully acquired the resource.");

            Thread.Sleep(Random.Shared.Next(1, 6) * 1000);
            semaphore.Release();
            Console.WriteLine($"{threadName} released the resource.");
        }
        static void Main(string[] args)
        {
            var threads = Enumerable
                .Range(1, 10)
                .Select(i => new Thread(Worker))
                .ToArray();

            semaphore = new Semaphore(3, 3);

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start((i + 1).ToString());
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to quit.");
        }
    }
}

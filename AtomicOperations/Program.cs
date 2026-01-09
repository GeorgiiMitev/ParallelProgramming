namespace AtomicOperations
{
    internal class Program
    {
        static int sum = 0;

        static void Worker(object? state)
        {
            Interlocked.Increment(ref sum); // add 1 to sum atomically
            
        }
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                var t = new Thread(Worker);
                threads.Add(t);
                t.Start();
            }
            foreach (var thread in threads) thread.Join();
            Console.WriteLine(sum);
        }
    }
}

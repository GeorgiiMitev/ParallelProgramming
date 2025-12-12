namespace RaceConditionCont
{
    internal class Program
    {
        static List<int> numbersList = [1, 2, 3, 4, 5];

        static void ListReader()
        {
            DateTime startTime = DateTime.Now;
            while (DateTime.Now - startTime < TimeSpan.FromSeconds(5))
            {
                int n = numbersList[Random.Shared.Next(numbersList.Count)];
            }
        }
        static void ListAdder()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                lock (numbersList)
                {
                    numbersList.Add(i);
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");
            Thread[] threads = new Thread[4];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ListReader);
                threads[i].Start();
            }
            Console.WriteLine("Starting evil threads..");
            Thread[] evilThreads = new Thread[4];
            for (int i = 0; i < evilThreads.Length; i++)
            {
                evilThreads[i] = new Thread(ListAdder);
                evilThreads[i].Start();
            }
            foreach (Thread thread in evilThreads)
            {
                thread.Join();
            }
            Console.WriteLine("Done..");

        }
    }
}

namespace SimpleCache
{
    internal class Program
    {
        static ASimpleCache cache = new ASimpleCache();
        static void SampleRequestsWorker()
        {
            string key = Random.Shared.Next(1000).ToString();
            object data;
            if (cache.TryGetValue(key, out data))
            {
                //Great, data is in the cache, return it fast.
            }
            else
            {
                //Data is not in the cache
                //Produce the value, slowly.
                Thread.Sleep(200);
                data = key + key + key;
                cache.Add(key, data);
            }
        }

        static int operations = 0;
        static void Simulator()
        {

            Thread[] worker = new Thread[16];
            for (int i = 0; i < worker.Length; i++)
            {
                worker[i] = new Thread(() =>
                {
                    DateTime start = DateTime.Now;
                    while (DateTime.Now - start < TimeSpan.FromSeconds(10))
                    {
                        SampleRequestsWorker();
                        Interlocked.Increment(ref operations);
                    }
                });
                worker[i].Start();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please wait...");
            Simulator();
            Console.WriteLine($"Throughput {operations}");
        }
    }
}

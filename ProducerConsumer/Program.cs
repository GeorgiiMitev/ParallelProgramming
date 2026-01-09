namespace ProducerConsumer
{
    internal class Program
    {
        static AProducerConsumer pc;
        static void ProducerAgent()
        {
            DateTime startTime = DateTime.Now;
            while(DateTime.Now - startTime < TimeSpan.FromSeconds(10))
            {
                pc.PushData(Random.Shared.Next(1000));
                Thread.Sleep(Random.Shared.Next(10));
            }
        }
        static void ConsumerAgent(int data)
        {
            //Do something with the data...
            Console.WriteLine(data);
        }
        static void Main(string[] args)
        {
            pc = new AProducerConsumer(ConsumerAgent);
            pc.Run();
            List<Thread> producers = new List<Thread>();
            for (int i = 0; i < 4; i++)
            {
                var t = new Thread(ProducerAgent);
                producers.Add(t);
                t.Start();
                
            }
        }
    }
}

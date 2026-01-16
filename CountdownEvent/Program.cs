namespace CountdownEventDemo
{
    internal class Program
    {
        static CountdownEvent countdown = new CountdownEvent(3);

        static void Worker()
        {
            Thread.Sleep(Random.Shared.Next(5000));
            countdown.Signal();
        }
        static void Main(string[] args)
        {
            Thread[] workers = new Thread[3];
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Thread(Worker);
                workers[i].Start();
            }
            Console.WriteLine("Wait for all to finish");
            countdown.Wait();
        }
    }
}

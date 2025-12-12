namespace RaceCondition
{
    internal class Program
    {
        static int Data = 100;

        static void WorkerUnsafe(object objTag)
        {
            string tag = (string)objTag;
            for(int i = 0; i < 10; i++)
            {
                Data = Data + 1;
                Thread.Sleep(3);
                Data = Data - 1;
                Console.WriteLine($"{tag}: {Data}");
            }
        }
        static void WorkerMonitor(object objTag)
        {
            string tag = (string)objTag;
            for (int i = 0; i < 10; i++)
            {
                Data = Data + 1;
                Thread.Sleep(3);
                Data = Data - 1;
                Console.WriteLine($"{tag}: {Data}");
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(WorkerUnsafe);
            Thread t2 = new Thread(WorkerUnsafe);
            t1.Start("A");
            t2.Start("B");
            t1.Join();
            t1.Join();
        }
    }
}

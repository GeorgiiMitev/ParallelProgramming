namespace ThreadPriorities;

internal class Program
{
    static void ThreadWorker()
    {
        while (true) ;
    }
    static void Main(string[] args)
    {
        Thread[] threads = new Thread[16];

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(ThreadWorker);
            threads[i].Priority = ThreadPriority.Lowest;
            threads[i].Start();
        }

    }
}

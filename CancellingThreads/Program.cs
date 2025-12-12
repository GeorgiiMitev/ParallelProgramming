namespace CancellingThreads
{
    internal class Program
    {
        static bool cancelationRequested = false;
        static bool completedSuccessfully = false;
        static void Worker()
        {
            for (int i = 0; i < 100; i++)
            {
                if (cancelationRequested == true)
                {
                    break;
                }
                Thread.Sleep(100);
            }
            completedSuccessfully = true;
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(Worker);

            Console.WriteLine("Starting a long job");
            thread.Start();

            Console.Write("Progress: ");
            while (thread.Join(100) is false)
            {
                Console.Write(".");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo c = Console.ReadKey();
                    if (c.KeyChar == 'c')
                    {
                        cancelationRequested = true;
                    }
                }

            }
            if (completedSuccessfully)
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Job was canceled.");
            }



        }
    }
}

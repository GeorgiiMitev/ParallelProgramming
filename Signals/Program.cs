namespace Signals
{
    internal class Program
    {
        //This works in c# and x86 but may not work elsewhere
        //static bool ShouldCancel = false;

        //instructs the compielr to NOT optimise usages
        //of this variable ( like caching its readability )
        static volatile bool ShouldCancel = false;


        //Best. Use a dedicated instrument
        static ManualResetEventSlim CancelEvent = new ManualResetEventSlim(false);

        static void WorkerWithCancellation()
        {
            Console.WriteLine("Thread started");
            for (int i = 0; i < 100; i++)
            {
                if (CancelEvent.Wait(0) is true)
                {
                    Console.WriteLine("Thread is cancelled.");
                    return;
                }
                Thread.Sleep(100);
            }
            Console.WriteLine("Thread ran to completion");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Starting some work. Press 'c' to cancel it");
            Thread thread = new Thread(WorkerWithCancellation);
            thread.Start();

            CancelEvent.Reset(); // sets the flag to not-signaled

            while(thread.Join(0) is false)
            {
                if (Console.KeyAvailable && Console.ReadKey().KeyChar == 'c')
                {
                    CancelEvent.Set();
                    Console.WriteLine("Thread signaled to cancel. Now waiting for it");
                    thread.Join();
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to quit");
        }
    }
}

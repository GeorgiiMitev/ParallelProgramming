namespace OrchestrationWithSignals
{
    internal class Program
    {
        static ManualResetEventSlim signalOne = new();
        static ManualResetEventSlim signalTwo = new();

        static int Value;

        static void WorkerOne()
        {
            Console.WriteLine("One started and is doing some work.");
            Thread.Sleep(2000);
            //Produce a value for two to use
            Value = 42; 
            signalTwo.Set();

            Console.WriteLine("One is doing some more work.");
            Thread.Sleep(1000);
            Console.WriteLine("One must now wait in turn for Two");
            signalOne.Wait();
            Console.WriteLine("One says: Two is ready, I can proceed.");
            Thread.Sleep(1000);
            Console.WriteLine("One ran to completion.");
        }
        static void WorkerTwo()
        {
            Console.WriteLine("Two started and is doing some work.");
            Thread.Sleep(1000);
            Console.WriteLine("Two must not wait for one to provide some input.");
            signalTwo.Wait();
            Console.WriteLine($"Two says: I got {Value}");
            Console.WriteLine("Two is doing some more work.");
            Thread.Sleep(3000);
            Value = Value * 2;
            signalOne.Set();
            Console.WriteLine("Two ran to completion");
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(WorkerOne);
            Thread thread2 = new Thread(WorkerTwo);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
    }
}

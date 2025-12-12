namespace CreateThread
{
    internal class Program
    {
        static void ThreadMethod()
        {
            Console.WriteLine("Hello from my first thread.");
        }

        static void Main(string[] args)
        {
            Thread myFirstThread = new Thread(ThreadMethod);
            myFirstThread.Start();

            Console.WriteLine("Hello.");


        }
    }
}

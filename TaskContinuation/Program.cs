namespace TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<int> t1 = Task.Run(() => 42);

            Task<int> t2 = t1.ContinueWith(previous => previous.Result * 2);

            Task t3 = t2.ContinueWith(previous => Console.WriteLine(previous.Result));

            t3.Wait();

            Console.ReadLine();
        }
    }
}

namespace WhyTasks
{
    internal class Program
    {
        static int CalcValue()
        {
            Thread.Sleep(1000);
            return 42;
        }
        static void Main(string[] args)
        {
            MyThread<int> myThread = new MyThread<int>(CalcValue);
            myThread.Run();
            
            try
            {
                //myThread.Wait();
                Console.WriteLine(myThread.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

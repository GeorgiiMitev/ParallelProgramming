namespace TasksIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a task
            Task task = new Task(() => Console.WriteLine("Hello from my first task."));
            task.Start();

            // You can also create a task like this:
            Task task2 = Task.Run(() => Console.WriteLine("Hello from my second task."));

            // How to wait for a task
            task2.Wait();

            // Task Results:
            Task<int> task3 = Task.Run(() => { Thread.Sleep(1000); return 42; });

            // Getting the result will block until task runs to completion or crashes
            int result = task3.Result;

            // Catching errors from tasks:
            Task<int> task4 = Task.Run(() => { throw new InvalidOperationException("Operation failed"); return 42; });

            try
            {
                task4.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}

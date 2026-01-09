namespace FanOutIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task firstTask = Task.Run(() => Console.WriteLine("Task 1 will fan out three others."));

            // Fan out five tasks from firstTask
            List<Task> fanOutTasks = Enumerable
                .Range(0, 5)
                .Select(i => firstTask.ContinueWith(t => Console.WriteLine("Fanning out task 1")))
                .ToList();

            // Now fan in: run a task after all five continuations complete.
            // fanInTask will complete when all fanOutTasks complete.
            // fanInTask does nothing else but wait for all fanOutTasks
            Task fanInTask = Task.WhenAll(fanOutTasks);

            Task finalTask = fanInTask.ContinueWith(t => Console.WriteLine("All Done."));

            Console.ReadLine();
        }
    }
}

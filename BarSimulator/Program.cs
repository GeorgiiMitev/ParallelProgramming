namespace BarSimulator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Bar bar = new Bar();
            List<Student> students = new List<Student>();

            int numberOfStudents = 50;
            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = new Student(i.ToString(), bar);
            }

            Thread barThread = new Thread(bar.Run);
            barThread.Start();


            Thread[] studentThreads = students
                .Select(s => new Thread(s.PaintTheTownRed))
                .ToArray();

            foreach (Thread studentThread in studentThreads)
            {
                studentThread.Start();
            }
            foreach (Thread studentThread in studentThreads)
            {
                studentThread.Join();
            }

            Console.WriteLine();
            Console.WriteLine("press enter to quit");
        }
    }
}

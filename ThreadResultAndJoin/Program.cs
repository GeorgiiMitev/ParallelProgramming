namespace ThreadResultAndJoin
{
    internal class Program
    {

        static int threadResult;

        //class Answer
        //{
        //    public int Value { get; set; }
        //}

        //static void GetUltimateAnswer(object objectAnswer)
        //{
        //    int answer;
        //    Thread.Sleep(5000);
        //    answer = 42;
        //    threadResult = 42;
        //    ((Answer)objectAnswer).Value = 42;

        //}
        static void GenerateRandomNumber()
        {
            int randomNum = Random.Shared.Next(10);
            threadResult = randomNum;
        }
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[6];
            int sum = 0;
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(GenerateRandomNumber);
                threads[i].Start();
                sum += threadResult;
                Console.WriteLine($"+ \t{threadResult}");
                

            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("-------------------");
            Console.WriteLine($"=\t{sum}");
           


            //Console.WriteLine("I will find the ultimate answeeerrrr!");
            //Answer answer = new Answer();

            //Thread t = new Thread(GetUltimateAnswer);
            //t.Start(answer);
            //Console.WriteLine("Waiting for thread to finish...");
            ////t.Join(); // blocks the Main thread until 't' finishes its execution

            //while(t.Join(200) is false)
            //{
            //    Console.Write(".");
            //}

            //Console.WriteLine("And the answer is: ");
            //Console.WriteLine(answer.Value);
        }
    }
}

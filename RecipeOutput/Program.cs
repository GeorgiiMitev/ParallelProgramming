using System.Diagnostics;

namespace RecipeOutput
{
    internal class Program
    {
        public static string[] steps = new string[]
        {
            "Washing & Cutting the meat into cubes.",
            "Pouring oil into the pan.",
            "Heating the pan.",
            "Stirring and cooking the meat until golden",
            "Taking the meat out and setting it aside",
            "Adding more oil",
            "Washing and peeling onions and carrots",
            "Stirring and cooking onions until semi-transparent",
            "Adding carrots, stirring and cooking for 2 minutes",
            "Returning meat in the pan",
            "Adding tomate paste",
            "Adding stock",
            "Adding salt & black pepper",
            "Bringing it to boil",
            "Letting it simmer for 1 hour",
            "Peeling potatoes",
            "Boiling potatoes",
            "Cutting boiled potatoes into small pieces",
        };
        public static void Worker()
        {
            Thread.Sleep(Random.Shared.Next(3000, 6000));
            Console.WriteLine($"{steps[Random.Shared.Next(1, 18)]}");
            
            

        }
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[steps.Length];
            for (int i = 0; i < threads.Length; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                threads[i] = new Thread(Worker);
                threads[i].Start();                
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}

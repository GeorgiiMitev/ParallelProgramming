

namespace WordAnalyzer
{
    internal class Program
    {
        static List<string> words = new List<string>();

        static void NumberOfWords()
        {
            Console.WriteLine($"Total words: {words.Count()}");

        }
        static void ShortestWord()
        {
            int longestWordLength = words.Min(word => word.Length);
            if (words.Min(word => word.Length) < 3)
            {
                foreach (var word in words)
                    if (words.Min(word => word.Length) < 3)
                    {
                        words.Remove(word);
                    }   
            }
            Console.WriteLine($"Shortest word length: {longestWordLength}");
        }
        static void LongestWord()
        {
            int longestWordLength = words.Max(word => word.Length);
            Console.WriteLine($"Longest word length: {longestWordLength}");
        }
        static void AverageWordLength()
        {
            double averageWordLength = words.Average(word => word.Length);
            Console.WriteLine($"Average word length: {Math.Round(averageWordLength)}");
        }
        static void FiveMostCommonWords()
        {

        }
        static void FiveLeastCommonWords()
        {

        }

        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("D:\\users\\fmi\\Desktop\\C# Parallel Programming\\bookText.txt");
            string text = sr.ReadToEnd();


            words = text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries).ToList();
            words.Remove("https://biblioman.chitanka.info/books/10213");
            words.Remove("978-954-28-2658-3");



            //NumberOfWords();




            //foreach (var word in words)
            //{
            //    Console.WriteLine(word.Length);
            //}
            //int result = 0;
            //foreach (var word in words)
            //{
            //    result = (words.Count());
            //}
            //Console.WriteLine(result);


        }
    }
}

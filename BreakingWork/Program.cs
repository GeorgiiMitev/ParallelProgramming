using System.Diagnostics;

namespace BreakingWork
{
    internal class Program
    {
        static int minValue = 100_000;
        static int maxValue = 2_000_000;

        record NumberDivisors(int Number, int DivisorCount);

        static int CountDivisors(int number)
        {
            int result = 0;
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    result++;
                }
            }
            return result;
        }
        static NumberDivisors FindMaxDivisors(int min, int max)
        {
            int number = 0, divisors = 0;
            for(int n = min; n <= max; n++)
            {
                int currentDivisors = CountDivisors(n);
                if (currentDivisors > divisors)
                {
                    number = n;
                    divisors = currentDivisors;
                }
            }
            return new NumberDivisors(number, divisors);
        }
        class DivisorWorkerParams
        {
            public int Index { get; set; }
            public int MinValue {  get; set; }
            public int MaxValue { get; set; }
            public NumberDivisors[] ResultPlaceholder { get; set; }
        }
        static void DivisorWorker(object objParam)
        {
            DivisorWorkerParams p = (DivisorWorkerParams)objParam;
            p.ResultPlaceholder[p.Index] = FindMaxDivisors(p.MinValue, p.MaxValue);
        }
        static NumberDivisors FindMaxDivisorsParallel(int chunks)
        {
            NumberDivisors[] chunkResults = new NumberDivisors[chunks];
            Thread[] threads = new Thread[chunks];
            int startValue = minValue;
            int chunkSize = (maxValue - minValue) / chunks;
            for (int i = 0; i < chunks; i++)
            {
                var threadParams = new DivisorWorkerParams()
                {
                    Index = i,
                    MinValue = startValue,
                    MaxValue = startValue + chunkSize,
                    ResultPlaceholder = chunkResults,
                };
                threads[i] = new Thread(DivisorWorker);
                threads[i].Start(threadParams);

                startValue = startValue + chunkSize;
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            return chunkResults.MaxBy(cr => cr.DivisorCount);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Finding the number with max divisors");

            Console.Write("Sequential: ");
            Stopwatch sw = Stopwatch.StartNew();
            var resultSeq = FindMaxDivisors(minValue, maxValue);
            sw.Stop();
            Console.WriteLine($"Ellapsed time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"{resultSeq.Number} has {resultSeq.DivisorCount} divisors");
            Console.WriteLine();
            int chunks = 16;
            Console.WriteLine($"Parallel, chunk size {chunks}");
            sw = Stopwatch.StartNew();
            var resultParallel = FindMaxDivisorsParallel(chunks);
            sw.Stop();
            Console.WriteLine($"Ellapsed time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"{resultParallel.Number} has {resultParallel.DivisorCount} divisors");

        }
    }
}

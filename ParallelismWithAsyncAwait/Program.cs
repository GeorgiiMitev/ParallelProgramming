namespace ParallelismWithAsyncAwait
{
    internal class Program
    {
        static async Task<int> CalculateValueAsync()
        {
            await Task.Delay(Random.Shared.Next(1000, 3000));
            return Random.Shared.Next(1, 11);
        }
        static async Task DoSomethingAsync()
        {
            Console.WriteLine("Calling my services...");

            //This will run async operations one *AFTER* another,
            //making the total exexcution almost sync
            //int value1 = await CalculateValueAsync();
            //int value2 = await CalculateValueAsync();
            //int value3 = await CalculateValueAsync();

            //This will make the three tasks run in *parallel*
            Task<int> t1 = CalculateValueAsync();
            Task<int> t2 = CalculateValueAsync();
            Task<int> t3 = CalculateValueAsync();

            //Wait for them all (option 1)
            int value1 = await t1;
            int value2 = await t2;
            int value3 = await t3;

            //Wait for all of them (option 2)
            int[] values = await Task.WhenAll(t1, t2, t3);
            value1 = values[0];
            value2 = values[1];
            value3 = values[2];

            Console.Write("Aggregated result:");
            Console.WriteLine(value1 + value2 + value3);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

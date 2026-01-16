using System.Threading.Tasks;

namespace AsyncAwaitExceptions
{
    internal class Program
    {
        static async Task FaultyMethodAsync()
        {
            await Task.Delay(500);
            throw new InvalidOperationException();
        }
        static async Task Main(string[] args)
        {
            try
            {
                await FaultyMethodAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}

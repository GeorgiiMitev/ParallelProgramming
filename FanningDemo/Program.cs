using System.Net;
using System.Threading.Tasks;

namespace FanningDemo
{
    internal class Program
    {
        const string url = $"https://nvp-functions.azurewebsites.net/api/qotd?slow=true";
        static string GetQoTD(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
        static async Task Main(string[] args)
        {
            List<Task<string>> taskQuote = new List<Task<string>>();
            for (int i = 0; i < 5; i++)
            {
                taskQuote.Add(Task.Run(() => GetQoTD(url)));
            }

            // Do something when all of these complete.
            Task<string[]> taskQuotesCompleted = Task.WhenAll(taskQuote);
            //Console.WriteLine("Waiting for all tasks to complete...");
            //Console.WriteLine();
            //taskQuotesCompleted.Wait();

            //foreach (var s in taskQuotesCompleted.Result)
            //{
            //    Console.WriteLine(s);
            //    Console.WriteLine();
            //}


            // Do something after each of these tasks complete.
            // Old school, before Net 10(9?)

            List<Task> continuations = new List<Task>();

            foreach (Task<string> task in taskQuote)
            {
                continuations.Add(task.ContinueWith(p =>
                {
                    Console.WriteLine(p.Result);
                    Console.WriteLine();
                }));
            }
            Task.WhenAll(continuations).Wait();


            await foreach (var t in Task.WhenEach(taskQuote))
            {
                Console.WriteLine(t.Result);
                Console.WriteLine();
            }
            
        }
    }
}

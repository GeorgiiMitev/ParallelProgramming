using System.Net;
using System.Net.Security;
using System.Threading.Tasks;

namespace AsyncResult
{
    internal class Program
    {
        const string url = "https://nvp-functions.azurewebsites.net/api/qotd?slow=true";

        static void MakeWebCall()
        {
            WebClient client = new WebClient();
            Console.WriteLine("Calling a web service...");
            string qotd = client.DownloadString(url);
            Console.WriteLine(qotd);
        }
        static void MakeWebCallAsyncResult()
        {
            WebClient client = new WebClient();
            Console.WriteLine($"Calling a web service... Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            client.DownloadStringCompleted += WebClient_DownnloadStringCompleted;
            client.DownloadStringAsync(new Uri(url));
        }
        private static void WebClient_DownnloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            string qotd = e.Result;
            Console.WriteLine(qotd);
        }
        static HttpClient client = new HttpClient();
        
        public static async Task MakeWebCallAsync()
        {
            Console.WriteLine("Making a web request...");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            string qotd = await client.GetStringAsync(url);
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(qotd);
        }

        public static void MakeWebCallAsyncIllustrate()
        {
            Console.WriteLine("Making a web request...");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Task<string> call = client.GetStringAsync(url);
            call.ContinueWith(p =>
            {
                string qotd = p.Result;
                Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine(qotd);
            });
        }

        static async Task Main(string[] args)
        {
            MakeWebCall();
            Console.WriteLine();
            //MakeWebCallAsyncResult();
            Console.WriteLine();
            await MakeWebCallAsync();
        }
    }
}

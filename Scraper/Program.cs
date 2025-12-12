using System.Linq.Expressions;
using System.Net;

namespace Scraper
{
    internal class Program
    {
        static string[] urls = [

            ];
        static List<decimal> prices = new List<decimal>();
        static void Worker(object objParam)
        {
            string url = (string)objParam;
            WebClient client = new WebClient();
            client.DownloadString(url);
            

            //lock (prices)
            //{
            //    prices.Add(price);
            //}
        }
        static void Main(string[] args)
        {
            Thread[] threads = urls.Select(url => new Thread(Worker)).ToArray();

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start(urls[i]);
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}

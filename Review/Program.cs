using System.Net;

namespace Review
{
    internal class Program
    {
        static List<int> numbers = [];
        static void Worker()
        {
            for (int i = 0; i < 1000; i++)
            {
                int newNumber = Random.Shared.Next();
                lock (numbers)
                {
                    numbers.Add(newNumber);
                }
            }
        }
        static void Main(string[] args)
        {
            //var threads = Enumerable.Range(0, 8).Select(i => new Thread(Worker)).ToArray();
            //foreach (var thread in threads)
            //{
            //    thread.Start();
            //}
            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}
            WebClient client = new WebClient();
            string index = "<p class=\"product-new-price\">";
            string endIndex;
            string[] links =
            {
                "https://www.emag.bg/smartfon-apple-iphone-17-pro-256gb-5g-cosmic-orange-mg8h4zd-a/pd/D099FV3BM/?ref=profiled_categories_home_all_first_ml_1_2&provider=rec&recid=rec_106_846d842a917272a5c82697dd077b1832dfcfe3e8e2601042b0eadaa22a1a98d7_1765525045&scenario_ID=106",
                "https://www.emag.bg/televizor-samsung-qled-55q7f2-55-138-sm-smart-4k-ultra-hd-klas-g-model-2025-qe55q7f2auxxh/pd/DT3GRT3BM/?ref=profiled_categories_home_all_fourth_ml_4_3&provider=rec&recid=rec_106_bace18e85215ef328d42ca79d3bcbf15e4ea80a616d318d7d9d5da4284f40ec7_1765525912&scenario_ID=106",
                "https://www.emag.bg/vertikalna-prahosmukachka-dyson-v15-detect-absolute-lcd-displej-660-w-0-77-l-avtonomija-60-min-zhylt-nikel-446986-01/pd/DFJLLYYBM/?ref=profiled_categories_home_all_third_ml_3_4&provider=rec&recid=rec_106_4367a6ffd0bb0ea9bbb14b7a0d023559c97ae0747a257c8dc40573163b992e97_1765527199&scenario_ID=106",
                "https://www.emag.bg/legor-creator-3-v-1-ekzotichen-papagal-31136-253-chasti-5702017415895/pd/D0GCYRMBM/?ref=profiled_categories_home_all_sixth_ml_6_3&provider=rec&recid=rec_106_a73c2d2a5218e8dac12fe03853fe6fb7992f71d6547811cd1e8598dcb84a03f4_1765526798&scenario_ID=106"
            };
            //foreach (string link in links)
            //{
            //    client.DownloadString(link);
            //}

            
            string html = client.DownloadString("https://www.emag.bg/smartfon-apple-iphone-17-pro-256gb-5g-cosmic-orange-mg8h4zd-a/pd/D099FV3BM/?ref=profiled_categories_home_all_first_ml_1_2&provider=rec&recid=rec_106_846d842a917272a5c82697dd077b1832dfcfe3e8e2601042b0eadaa22a1a98d7_1765525045&scenario_ID=106");
            int priceIndex = html.IndexOf("<p class=\"product-new-price\">");
            while (Char.IsDigit(html[priceIndex]))
            {
                priceIndex++;
                
            }
            int takeN = html.IndexOf("<p class=\"product-new-price\">") - html.IndexOf("<p class=\"product-new-price\">" + "<".Length);
            Console.WriteLine(html.Skip(html.IndexOf("<p class=\"product-new-price\">")).Skip(index.Length).Take(takeN).ToArray());
            //Console.WriteLine(html.Skip(html.IndexOf(index, 0, html.Length)).Skip(index.Length).Take(7).Concat(" лв.").ToArray());
            
            
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {


            string url1 = "https://...";
            string url2 = "https://...";

            Console.Write("Téléchargement...");
            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);


            //await downloadTask1;
            //await downloadTask2;

            await Task.WhenAll(downloadTask1, downloadTask2);

            Console.WriteLine("Fin du programme");


            
        }

        static async Task DownloadData(string url)
        {
            var httpClient = new HttpClient();
            

            var resultat = await httpClient.GetStringAsync(url);
            

            Console.WriteLine($"OK -> {url}");

            //Console.WriteLine(resultat);
        }

        static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
    }
}

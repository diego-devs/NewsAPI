using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace NewsAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var q = args.ToString();
            var language = "es";
            var from = DateTime.Now.ToShortDateString();
            
            var url = "http://newsapi.org/v2/everything?" +
            $"q={q}&" +
            $"language={language}&" +
            $"from={from}&" +
            "sortBy=popularity&" +
            "apiKey=fb86b898844247fb9b0000140cc3838c";

            var myClient = new HttpClient() {BaseAddress = new Uri(url)};
            var request = await myClient.GetAsync(myClient.BaseAddress);

            var myModel = new Model();
            var count = 0;

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<Model>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                System.Console.WriteLine(model.Status + " Artículos encontrados: " +  model.Articles.Count);
                myModel = model;
            }
            else
            {
                Console.WriteLine("No funciona");
            }

            foreach (var art in myModel.Articles) {
                count++;
                System.Console.WriteLine("Artículo: " + count);
                System.Console.WriteLine(art.Title);
                System.Console.WriteLine(art.Source.Name);
                System.Console.WriteLine(art.Description);
                System.Console.WriteLine(art.PublishedAt);
                System.Console.WriteLine(art.Content);
            }

            var newUrl = myModel.Articles[1].Url;
            System.Diagnostics.Process.Start(newUrl);
        }
    }
}

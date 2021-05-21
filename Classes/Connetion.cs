using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsAPI 
{
    public abstract class Connection 
    {
        public static async Task EstablishConnection(string search, string language)
            {
                var q = search;
                var lang = language;
                var from = DateTime.Now.ToShortDateString(); // Fecha actual
                
                var url = "http://newsapi.org/v2/everything?" +
                $"q={q}&" +
                $"language={lang}&" +
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
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine("Artículo: " + count);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine(art.Title.ToUpper());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine(art.Source.Name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine(art.Description);
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine(art.PublishedAt);
                    System.Console.WriteLine(art.Content);
                }

            }
    }
}
    
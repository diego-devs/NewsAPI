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
        public static async Task<Model> EstablishConnectionAsync(string search, string language)
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
                

                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();             
                    var model = JsonSerializer.Deserialize<Model>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    System.Console.WriteLine(model.Status + " Artículos encontrados: " +  model.Articles.Count);
                    myModel = model;
                }
                else
                {
                    Console.WriteLine("Request error");
                }
                return myModel;
            }
    }
}
    
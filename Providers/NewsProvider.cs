using NewsApp.Interfaces;
using NewsApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsApp.Providers
{
    public class NewsProvider : INewsProvider
    {
        public async Task<List<Article>> GetArticlesAsync(string search)
        {
            var q = search;
            var lang = "en";
            var from = DateTime.Now.ToShortDateString(); // Fecha actual

            var url = "http://newsapi.org/v2/everything?" +
            $"q={q}&" +
            $"language={lang}&" +
            $"from={from}&" +
            "sortBy=popularity&" +
            "pageSize=100&" +
            "apiKey=fb86b898844247fb9b0000140cc3838c";

            var myClient = new HttpClient() { BaseAddress = new Uri(url) };

            try
            {
                var request = await myClient.GetAsync(myClient.BaseAddress);


                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();
                    var model = JsonSerializer.Deserialize<NewsModel>
                                            (content, new JsonSerializerOptions() 
                                                        { PropertyNameCaseInsensitive = true }
                                            );
                    var Articles = new List<Article>(model.Articles);
                    return Articles;
                }
                else
                {
                    Console.WriteLine("Request error");
                    return null;
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error" + e.Message);

            }
            
        }

        Task<Article> INewsProvider.GetArticleAsync()
        {
            throw new NotImplementedException();
        }
    }
}

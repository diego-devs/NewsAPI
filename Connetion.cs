using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsAPI 
{
    public static class Connection 
    {
        
        private static readonly HttpClient client = new HttpClient()
        { 
            BaseAddress = new Uri("http://newsapi.org/v2/everything?") 
        };
        public static async Task<List<Article>> GetArticlesSearchAsync(string _lang, string _search)
        {
            var q = _search; 
            var lang = _lang;
            var from = DateTime.Now.ToShortDateString(); // Fecha actual
            var url = client.BaseAddress;
            var endpoint = url +
            $"q={q}&" +
            $"language={lang}&" +
            $"from={from}&" +
            "sortBy=popularity&" +
            "apiKey=fb86b898844247fb9b0000140cc3838c";

            try
            {
                var answer = new Answer();
                var response = await client.GetStringAsync(endpoint);

                if (response != null)
                {
                    answer = JsonSerializer.Deserialize<Answer>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    System.Console.WriteLine(answer.Status + " Found articles: " + answer.Articles.Count);
                    return new List<Article>(answer.Articles);
                }
                
                else
                {
                    Console.WriteLine("Request error" + response);
                    Console.WriteLine(response.ToString());
                    return null;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
    
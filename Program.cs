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
        
        public static async Task Main(string[] args) 
        {
            COMIENZO:
            System.Console.WriteLine("Select language (en, es, por, ita, fra, ale): ");
            var lang = Console.ReadLine();

            System.Console.WriteLine("Search:");
            var search = Console.ReadLine();
            
            try
            {
                var myArticles = await Connection.EstablishConnectionAsync(search, lang);
                var count = 0;
                foreach (var art in myArticles.Articles)
                {
                    count++;
                    LogArticle(count, art);
                }

            }
            catch (System.Exception n)
            {
                System.Console.WriteLine("Error connection" + n.Message);
            }


            System.Console.WriteLine("Do you want to search again? y/n");
            var response = Console.ReadLine();
            if (response == "y") 
            {
                goto COMIENZO;
            } 
            else if (response == "n") 
            {
                Environment.Exit(0);
            } 
            else 
            { 
                Environment.Exit(0);
            }
        }
        private static void LogArticle(int count, Article art)
        {
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
            System.Console.WriteLine(art.Url);
        }
    }
}

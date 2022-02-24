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
            START:
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

            RETURNANSWER:
            System.Console.WriteLine("Search again? y/n");
            var response = Console.ReadLine();
            if (response == "y") 
            {
                goto START;
            } 
            else if (response == "n") 
            {
                Environment.Exit(0);
            } 
            else 
            { 
                goto RETURNANSWER;
            }
        }
        private static void LogArticle(int count, Article art)
        {
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Article: " + count);
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

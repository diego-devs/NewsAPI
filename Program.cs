using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
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

                var myArticles = await Connection.GetArticlesSearchAsync(search, lang);
                if (myArticles != null)
                {
                    var count = 0;
                    foreach (var article in myArticles)
                    {
                        count++;
                        Console.WriteLine(count);
                        article.Print();
   
                    }
                }
                else
                {
                    Console.WriteLine("Not a single article was found. Check connection.");
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
        
    }
}

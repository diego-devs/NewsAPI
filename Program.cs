using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsAPI
{
    public static class Program
    {      
        public static async Task Main(string[] args) 
        {    
            // ask input
            var input = GetUserInput();
            // make search
            if (input != null) 
            {
                try
                {
                    var myArticles = await Connection.GetArticlesSearchAsync(input[0], input[1]);
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
            }
            else {
                Console.WriteLine("No search and a language in input");
            }
        }
        private static string[] GetUserInput() 
        {
            System.Console.WriteLine("Select language (en, es, por, ita, fra, ale): ");
            var lang = Console.ReadLine();
            System.Console.WriteLine("Search:");
            var search = Console.ReadLine();
            return new string[] {lang, search};
        }
    }
}

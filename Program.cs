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
            System.Console.WriteLine("Ingresa el lenguage (en, es, por, ita, fra, ale): ");
            var lang = Console.ReadLine();

            System.Console.WriteLine("Ingresa las palabras clave:");
            var search = Console.ReadLine();

            await Connection.EstablishConnection(search, lang); 
        
        }
    }
}

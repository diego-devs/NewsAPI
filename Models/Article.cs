using System;

namespace NewsAPI
{
    public class Article
    {
        public Source Source { get; set; }
        public string Author {get; set;}
        public string Title {get; set;}
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage {get; set;}
        public string PublishedAt { get; set; }
        public string Content { get; set; }

        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Article: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine(Title.ToUpper());
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(Source.Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine(Description);
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(PublishedAt);
            System.Console.WriteLine(Content);
            System.Console.WriteLine(Url);
        }
    }
}
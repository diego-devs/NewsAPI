using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsAPI
{
    public class Model {
        
        public string Status { get; set; }
        public int TotalResults {get; set;}
        public List<Article> Articles {get; set;}
    }
}
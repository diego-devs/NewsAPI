using System.Collections.Generic;

namespace NewsApp.Models
{
    public class NewsModel

    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}

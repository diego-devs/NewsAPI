using NewsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApp.Interfaces
{
    public interface INewsProvider
    {
        public Task<Article> GetArticleAsync();
        public Task<List<Article>> GetArticlesAsync(string search);
    }
}

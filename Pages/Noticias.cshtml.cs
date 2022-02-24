using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsApp.Interfaces;
using NewsApp.Models;
using NewsApp.Providers;

namespace NewsApp.Pages
{
    public class NoticiasModel : PageModel
    {
        public static List<Article> Articles { get; set; }

        private readonly INewsProvider newsProvider;

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public NoticiasModel( INewsProvider newsProvider)
        {
            this.newsProvider = newsProvider;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var results = await newsProvider.GetArticlesAsync(Search);
                if (results != null)
                {
                    Articles = new List<Article>(results);
                }
            }
            else
            {
                var results = await newsProvider.GetArticlesAsync("Ukraine");
                if (results != null)
                {
                    Articles = new List<Article>(results);
                };

            }
            return Page();

        }
    }
}

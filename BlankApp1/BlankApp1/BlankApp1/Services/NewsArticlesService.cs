using System;
using System.Collections.Generic;
using System.Text;
using Core.Services;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services
{
    public class NewsArticlesService : INewsArticlesService
    {
        private static List<NewsArticles> NewsArticles = new List<NewsArticles>
        {
             new NewsArticles
            {
                Name = "Niewsartikel 1 ",
                Image = "https://propertynl.com/media/newsarticle/photos/104838/27416/Camelot.png?w=330"
            },
             new NewsArticles
            {
                Name = "Niewsartikel 2 ",
                Image = "https://propertynl.com/media/newsarticle/photos/104854/27434/Atlantic-Huis.jpg?w=330"
            },
             new NewsArticles
            {
                Name = "Niewsartikel 3 ",
                Image = "https://propertynl.com/media/newsarticle/photos/104853/27433/Indruk-nieuwe-pui-units-LU-1-6-SPAA-2.jpg?w=330"
            },
             new NewsArticles
            {
                Name = "Niewsartikel 4 ",
                Image = "https://propertynl.com/media/newsarticle/photos/104847/27427/photo-about-fcf87eb87d8a8fef13f67b5a2664f86e.png?w=330"
            },

        };
        public async Task<List<NewsArticles>> GetNewsArticles()
        {
            await Task.Delay(500);

            return NewsArticles;
            
        }
    }
}

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
                Id = 1,
                Title = "Advertentie 1",
                Description = "De stad Utrecht, de snelst gooiende gemeenste in Nederland, wil met ontwikkelaars, corporaties en beleggers tot een Stadsakkoord Wonen komen.",
                Image = "https://propertynl.com/media/newsarticle/photos/104838/27416/Camelot.png?w=330"
            },
             new NewsArticles
            {
                Id = 2,
                Title = "test1",
                Description = "De stad Utrecht, de snelst gooiende gemeenste in Nederland, wil met ontwikkelaars, corporaties en beleggers tot een Stadsakkoord Wonen komen.",
                Image = "https://propertynl.com/media/newsarticle/photos/104854/27434/Atlantic-Huis.jpg?w=330"
            },
             new NewsArticles
            {
                Id =3,
                Title = "test2",
                Description = "De stad Utrecht, de snelst gooiende gemeenste in Nederland, wil met ontwikkelaars, corporaties en beleggers tot een Stadsakkoord Wonen komen.",
                Image = "https://propertynl.com/media/newsarticle/photos/104853/27433/Indruk-nieuwe-pui-units-LU-1-6-SPAA-2.jpg?w=330"
            },
             new NewsArticles
            {
                Id =4,
                Title = "Niewsartikel4",
                Description  = "Vastgoedbeleggingen bereiken recordhoogten in verkopersmarkt en de excessieve vraag drijft de prijzen van kantoorruimten op. Dat blijkt uit een rapport van advocatenkantoor CMS.",
                Image = "https://propertynl.com/media/newsarticle/photos/104847/27427/photo-about-fcf87eb87d8a8fef13f67b5a2664f86e.png?w=330"
            },

        };
        public NewsArticles GetNewsArticleById(Guid UniqueId)
        {
           // NewsArticles newsArticle = NewsArticles.Find(x => x.Id == Id);
            //return newsArticle;
            throw new NotImplementedException();
        }
        public async Task<List<NewsArticles>> GetNewsArticles()
        {
            await Task.Delay(500);

            return NewsArticles;
            
        }
    }
}

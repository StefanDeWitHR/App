using System;
using System.Collections.Generic;
using System.Text;
using Core.Helpers;
using Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RSSArticlesService : IRSSArticlesService
    {
        IHttpManager _httpManager = new HttpManager();

       public RSSArticlesService(IHttpManager httpManager)
        {
            _httpManager = httpManager;
        }

        public async Task<Rss> GetRSSArticles()
        {
            var result = await _httpManager.Get<Rss>("GetRSSArticles?newsChannel=NL&Sticky=True");

            return result;
        }
    }
}

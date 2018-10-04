using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
namespace Core.Services
{
    public interface INewsArticlesService
    {
        Task<List<NewsArticles>> GetNewsArticles();
      //  Task<ObservableCollection<NewsArticles>> GetNewsArticles();
    }
}

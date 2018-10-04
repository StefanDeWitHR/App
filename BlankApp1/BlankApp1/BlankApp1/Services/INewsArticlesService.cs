﻿using System;
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
        NewsArticles GetNewsArticleById(int Id);
      //  Task<ObservableCollection<NewsArticles>> GetNewsArticles();
    }
}

using Core.Models;
using Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class NewsArticlesPageViewModel : ViewModelBase, INavigationAware
    {
        private readonly INavigationService   _navigationService;
        private readonly INewsArticlesService _newsArticlesService;

        public NewsArticlesPageViewModel(INavigationService navigationService , INewsArticlesService newsArticlesService) : base(navigationService)
        {
            _navigationService = navigationService;
            _newsArticlesService = newsArticlesService;
        }

        private NewsArticles _newsArticle;
        public NewsArticles NewsArticle
        {
            get { return _newsArticle; }
            set
            {
                _newsArticle = value;
                RaisePropertyChanged();
            }
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            //
        }
  
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Id"))
                Title = (string)parameters["title"];
                int paramId = (int)parameters["Id"];
                NewsArticle = _newsArticlesService.GetNewsArticleById(paramId);   

        }
    }
}

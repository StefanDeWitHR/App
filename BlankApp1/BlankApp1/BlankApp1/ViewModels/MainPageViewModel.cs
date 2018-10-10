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

        public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly INewsArticlesService _newsArticleService;
        private readonly IRSSArticlesService _RSSArticlesService;
        // Commands
        public  DelegateCommand<object> GetNewsArticleCommand { get;  }
        
        //

        public MainPageViewModel(INavigationService navigationService, INewsArticlesService newsArticlesService , IRSSArticlesService RSSArticlesService)
            : base(navigationService)
        {
            Title = "Homepage";

            _newsArticleService = newsArticlesService;
            _RSSArticlesService = RSSArticlesService;
            _navigationService = navigationService;

            //Command Instances
            GetNewsArticleCommand = new DelegateCommand<object>(MoreInfoNewsArticle);
          

        }
        private int _position;
        public int Position { get { return _position; } set { _position = value; RaisePropertyChanged(); } }
        public async void MoreInfoNewsArticle(object param)
        {
            NewsArticles newsArticles = param as NewsArticles;

            var parameters = new NavigationParameters();
            parameters.Add("Id", newsArticles.Id);

            await _navigationService.NavigateAsync(new Uri("NavigationPage/NewsArticleDetailPage", UriKind.Relative), parameters);
        }

        private List<NewsArticles> _newsArticles;
        public List<NewsArticles> NewsArticles
        {
            get { return _newsArticles; }
            set
            {
                _newsArticles = value;
                RaisePropertyChanged();
            }
        }
        private Rss _RSSArticles;
        public Rss RSSArticles
        {
            get { return _RSSArticles; }
            set { _RSSArticles = value; RaisePropertyChanged(); }
        }


        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            NewsArticles = await _newsArticleService.GetNewsArticles();
            RSSArticles = await _RSSArticlesService.GetRSSArticles();
        }
    } 
}


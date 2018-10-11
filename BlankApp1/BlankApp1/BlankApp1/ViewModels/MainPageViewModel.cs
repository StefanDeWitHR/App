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
using System.Windows.Input;
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

        // Arrow navigation
        public ICommand OnNextRSSArticleCommand { get; }     
        public ICommand OnPrevRSSArticleCommand { get; }
        
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
            
            OnNextRSSArticleCommand = new Command(OnNextRSSArticle);
            OnPrevRSSArticleCommand = new Command(OnPrevRSSArticle);

        }
        
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

        private int _RSSArticlesPosition;
        public int RSSArticlesPosition
        {
            get { return _RSSArticlesPosition; }
            set { _RSSArticlesPosition = value; RaisePropertyChanged(); }
        }

        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            NewsArticles = await _newsArticleService.GetNewsArticles();
            RSSArticles = await _RSSArticlesService.GetRSSArticles();
            RSSArticlesPosition = 0;
        }

        // Navigation carasoulView
        void OnNextRSSArticle()
        {
            int totalCount = RSSArticles.channel.items.Count();
            if ((RSSArticlesPosition + 1) != totalCount)
            {
                RSSArticlesPosition++;
            }
            else
            {
                RSSArticlesPosition = 0;
            }

        }
        void OnPrevRSSArticle()
        {
            int totalCount = RSSArticles.channel.items.Count();
            if (RSSArticlesPosition == 0)
            {
                RSSArticlesPosition = totalCount - 1;
            }
            else
            {
                RSSArticlesPosition--;
            }
        }

    } 
}


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
using System.Linq;
namespace Core.ViewModels
{

        public class MainPageViewModel : ViewModelBase
        {
        private readonly INavigationService _navigationService;
        private readonly INewsArticlesService _newsArticleService;

        // Commands
        private DelegateCommand<NewsArticles> _GetNewsArticle;
        public DelegateCommand<NewsArticles> GetNewsArticleCommabnd => _GetNewsArticle ?? (_GetNewsArticle = new DelegateCommand<NewsArticles>(ItemSelected));
        //

        public MainPageViewModel(INavigationService navigationService, INewsArticlesService newsArticlesService)
            : base(navigationService)
        {
            Title = "Homepage";

            _newsArticleService = newsArticlesService;
            _navigationService = navigationService;


        }

        public async void ItemSelected (object args)
        {
            var p = new NavigationParameters();
            p.Add("item", args);

            await _navigationService.NavigateAsync("NewsArticlesPage", p);
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
        private NewsArticles _selectedItem;
        public NewsArticles SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            NewsArticles = await _newsArticleService.GetNewsArticles();
         //   NewsArticles = NewsArticles.ToList();
        }
    } 
}


using Core.Models;
using Core.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace Core.ViewModels
{
    public class NewsArticlesPageViewModel : ViewModelBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly INewsArticlesService _newsArticlesService;

        public DelegateCommand<object> GetNewsArticleCommand { get; }
        public DelegateCommand<object> SearchNewsArticleCommand { get; }

        public NewsArticlesPageViewModel(INavigationService navigationService, INewsArticlesService newsArticlesService)
       : base(navigationService)
        {
            Title = "Homepage";

            _newsArticlesService = newsArticlesService;
            _navigationService = navigationService;

            //Command instances
            GetNewsArticleCommand = new DelegateCommand<object>(MoreInfoNewsArticle);
            SearchNewsArticleCommand = new DelegateCommand<object>(SearchOnNewsArticle);

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
        private ObservableCollection<NewsArticles> _OC_NewsArticles;
        public ObservableCollection<NewsArticles> OC_NewsArticles
        {
            get
            {
                return _OC_NewsArticles;
            }
            set
            {
                _OC_NewsArticles = value;
                RaisePropertyChanged();
            }
        }
        public async override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            NewsArticles = await _newsArticlesService.GetNewsArticles();
        }
        public async void MoreInfoNewsArticle(object param)
        {
            NewsArticles newsArticles = param as NewsArticles;

            var parameters = new NavigationParameters();
            parameters.Add("Id", newsArticles.Id);

            await _navigationService.NavigateAsync(new Uri("NavigationPage/NewsArticleDetailPage", UriKind.Relative), parameters);
        }


        private string _KeyWord;
        public string KeyWord
        {
            get
            {
                return _KeyWord;
            }
            set
            {
                _KeyWord = value;
                RaisePropertyChanged();
            }
        }
        public async void SearchOnNewsArticle(object param)
        {
            //NewsArticles.Where(x => x.Name.Contains(keyWord));
            string keyWord = _KeyWord.ToLower();
            NewsArticles = _newsArticles.Where(x => x.Name.Contains(keyWord)).ToList();
            //NewsArticles = _newsArticles;

        }
    }
}

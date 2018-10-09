using Core.Models;
using Core.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class NewsArticlesPageViewModel : ViewModelBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly INewsArticlesService _newsArticlesService;

        public DelegateCommand<object> GetNewsArticleCommand { get; }


        private ICommand _SearchNewsArticleCommand;

        public NewsArticlesPageViewModel(INavigationService navigationService, INewsArticlesService newsArticlesService)
       : base(navigationService)
        {
            Title = "Homepage";

            _newsArticlesService = newsArticlesService;
            _navigationService = navigationService;

            //Command instances
            GetNewsArticleCommand = new DelegateCommand<object>(MoreInfoNewsArticle);

        }
        // Properties 
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
            NewsArticles = await _newsArticlesService.GetNewsArticles(); //Copy of the list
            OC_NewsArticles = new ObservableCollection<NewsArticles>(NewsArticles);
        }
        public async void MoreInfoNewsArticle(object param)
        {
            NewsArticles newsArticles = param as NewsArticles;

            var parameters = new NavigationParameters();
            parameters.Add("Id", newsArticles.Id);

            await _navigationService.NavigateAsync(new Uri("NavigationPage/NewsArticleDetailPage", UriKind.Relative), parameters);
        }
        public ICommand SearchNewsArticleCommand
        {
            get
            {
                return _SearchNewsArticleCommand ?? (_SearchNewsArticleCommand = new Command<string>((keyWord) =>
                {
                    OC_NewsArticles = new ObservableCollection<NewsArticles>(_newsArticles
                     .Where(x => x.Title.ToLower()
                     .Contains(keyWord.ToLower())).ToList());
                }));
            }
        }
    }
}

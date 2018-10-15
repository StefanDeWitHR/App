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
    public class NewsArticleDetailPageViewModel : ViewModelBase, INavigationAware
    {
        private readonly INavigationService   _navigationService;
        private readonly INewsArticlesService _newsArticlesService;

        //Commands
        public ICommand OnCategoryTappedCommand { get; }
        public ICommand OnBackNavigationCommand { get; }



        public NewsArticleDetailPageViewModel(INavigationService navigationService , INewsArticlesService newsArticlesService) : base(navigationService)
        {
            _navigationService = navigationService;
            _newsArticlesService = newsArticlesService;

            OnCategoryTappedCommand = new Command(NavigateToNewsArticleCategory);
            OnBackNavigationCommand = new Command(NavigateBack);
        }

        public async void NavigateBack()
        {
            await _navigationService.GoBackAsync();
        }
        public async void NavigateToNewsArticleCategory(object CategoryId)
        {

            var parameters = new NavigationParameters
            {
                { "CategoryId", CategoryId }
            };
           
            await _navigationService.NavigateAsync(new Uri("NewsArticlesPage", UriKind.Relative), parameters);
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
            if (parameters.ContainsKey("UniqueId"))
                Title = (string)parameters["title"];
                Guid UniqueId = (Guid)parameters["UniqueId"];
                //NewsArticle = _newsArticlesService.GetNewsArticleById(UniqueId);   

        }
    }
}

using Core.Models;
using Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Input;
using Core.Helpers;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Services;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class NewsArticleDetailPageViewModel : ViewModelBase , INavigatedAware
    {
        private readonly INavigationService   _navigationService;
        private readonly INewsArticlesService _newsArticlesService;
        private readonly IPermissionManager _permissionManager;


        //Commands
        public ICommand OnCategoryTappedCommand { get; }
        public ICommand OnBackNavigationCommand { get; }
        public DelegateCommand<object> NavigateToRedactorPageCommand { get; }
        public ICommand ShareItemCommand { get; }

        public NewsArticleDetailPageViewModel(
            INavigationService navigationService , 
            INewsArticlesService newsArticlesService,
            IPermissionManager permissionManager
            
           ) : base(navigationService)
        {
            _navigationService = navigationService;
            _newsArticlesService = newsArticlesService;
            _permissionManager = permissionManager;

            OnCategoryTappedCommand = new Command(NavigateToNewsArticleCategory);
            OnBackNavigationCommand = new Command(NavigateBack);
            NavigateToRedactorPageCommand = new DelegateCommand<object>(NavigateToRedactorPage);
            ShareItemCommand = new Command(ShareItemAsync);
        }

        public void ShareItemAsync()
        {
            var img = ImageSource.FromUri(new Uri(
                "https://propertynl.com/media/newsarticle/photos/105183/27801/Roosendaal-Yusen.jpg?w=690"));
            _permissionManager.ShareItemAsync("title" , "subject" , img);
        }
        public async void NavigateToRedactorPage(object RedactorId)
        {
            var parameters = new NavigationParameters
            {

                {"RedactorId", RedactorId}
            };
            await _navigationService.NavigateAsync(new Uri("RedactorPage", UriKind.Relative), parameters);

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

        public  void OnNavigatedFrom(INavigationParameters parameters)
        {
            //
        }
  
        public  void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("UniqueId"))
                Title = (string)parameters["title"];
                Guid UniqueId = (Guid)parameters["UniqueId"];
                //NewsArticle = _newsArticlesService.GetNewsArticleById(UniqueId);   

        }

    }
}

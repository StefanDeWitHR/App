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
using Plugin.FacebookClient;
using Plugin.FacebookClient.Abstractions;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class NewsArticleDetailPageViewModel : ViewModelBase , INavigatedAware
    {
        private readonly INavigationService   _navigationService;
        private readonly INewsArticlesService _newsArticlesService;

        //Commands
        public ICommand OnCategoryTappedCommand { get; }
        public ICommand OnBackNavigationCommand { get; }
        public DelegateCommand<object> NavigateToRedactorPageCommand { get; }
        public ICommand ShareItemOnFBCommand { get; }

        public NewsArticleDetailPageViewModel(INavigationService navigationService , INewsArticlesService newsArticlesService) : base(navigationService)
        {
            _navigationService = navigationService;
            _newsArticlesService = newsArticlesService;

            OnCategoryTappedCommand = new Command(NavigateToNewsArticleCategory);
            OnBackNavigationCommand = new Command(NavigateBack);
            NavigateToRedactorPageCommand = new DelegateCommand<object>(NavigateToRedactorPage);
            ShareItemOnFBCommand = new Command(ShareItemOnFacebook);
        }

        public async  void ShareItemOnFacebook()
        {
            // Example of image
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData("https://propertynl.com/media/newsarticle/photos/105168/27784/Frank_Mulders-20KPMG.jpg?w=690");

            FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(new string[] { "email", "public_profile" });
            FacebookSharePhoto[] photos = new FacebookSharePhoto[] { new FacebookSharePhoto("test", imageBytes) };
            FacebookSharePhotoContent photoContent = new FacebookSharePhotoContent(photos);
            await CrossFacebookClient.Current.ShareAsync(photoContent);
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

using Prism;
using Prism.Ioc;
using Core.ViewModels;
using Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using Core.Services;
using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Core.Helpers;
using System.Windows.Input;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Core
{
    public partial class App : PrismApplication
    {

        public App() : this(null) {

        }
       
        public static double ScreenHeight;
        public static double ScreenWidth;
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
           
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
         
             await NavigationService.NavigateAsync(new System.Uri("/MenuPage/NavigationPage/MainPage", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage , MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsArticleDetailPage, NewsArticleDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsArticlesPage, NewsArticlesPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage , MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ContactPage , ContactViewModel>();
            containerRegistry.RegisterForNavigation<AboutUsPage>();
            containerRegistry.RegisterForNavigation<TrialPage , TrialPageViewModel>(); 

            // Services 
            containerRegistry.Register<INewsArticlesService, NewsArticlesService>();
            containerRegistry.Register<IRSSArticlesService, RSSArticlesService>();
            containerRegistry.Register<IHttpManager, HttpManager>();

        }


        //  Social media icons
        private void OnFaceBookTapped(object sender, EventArgs e)
        {
            
            try
            {
                Device.OpenUri(new Uri("fb://page/943580452350442"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://www.facebook.com/pages/PropertyNL"));
            }
        }
        private void OnMailTapped(object sender, EventArgs e)
        {
            try
            {
                Device.OpenUri(new Uri("mailto:redactie@propertynl.com"));
            }
            catch
            {
                throw new Exception("Mail application not found on device");
            }
        }
        private void OnLinkedInTapped(object sender , EventArgs e)
        {
            try
            {
                Device.OpenUri(new Uri("https://www.linkedin.com/company/propertynl"));
            }
            catch
            {
                throw new Exception("Try again");
            }
            
        }
        private void OnTwitterTapped(object sender, EventArgs e)
        {
            try
            {
                 Device.OpenUri(new Uri("twitter://userName?user_id=propertynl"));
            }
            catch
            {
                Device.OpenUri(new Uri("https://twitter.com/propertynl"));
            }
         
        }
        private void OnPhoneTapped(object sender , EventArgs e)
        {
            try
            {
                Device.OpenUri(new Uri("tel:+31(0)88776 73 78"));

            }
            catch
            {
                throw new System.Exception("Something went wrong");
            }
        }

        // Open menu on tap
        private void OnMenuTapped(object sender, EventArgs e)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }

        // Android back button to prevent closing the application
        public bool CanGoBack
        {
            get
            {
                MasterDetailPage mainPage = App.Current.MainPage as MasterDetailPage;

                if (mainPage != null)
                {
                    bool canDoBack = mainPage.Detail.Navigation.NavigationStack.Count > 1 || mainPage.IsPresented;

                    
                    if (!canDoBack)
                    {
                        mainPage.IsPresented = true;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
        }

      
    }
}


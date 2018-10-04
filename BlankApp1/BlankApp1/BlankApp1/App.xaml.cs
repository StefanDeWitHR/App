using Prism;
using Prism.Ioc;
using Core.ViewModels;
using Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using Core.Services;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Core
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {

           
        }
       
        public static double ScreenHeight;
        public static double ScreenWidth;
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(new System.Uri("/MenuPage/NavigationPage/MainPage", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<NewsArticlesPage>();
            containerRegistry.RegisterForNavigation<MenuPage , MenuPageViewModel>();
       
            // Services 
            containerRegistry.Register<INewsArticlesService, NewsArticlesService>();
            
        }
    }
}

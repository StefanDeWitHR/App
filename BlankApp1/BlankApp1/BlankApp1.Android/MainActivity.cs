using Android.App;
using Android.Content.PM;
using Android.OS;
using App.Droid;
using Prism;
using Prism.Ioc;
using System.Reflection;
using Refractored.XamForms.PullToRefresh.Droid;

namespace App.Droid
{
    [Activity(Label = "PropertyNL", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private Core.App app;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            Stormlion.SNavigation.Droid.Platform.Init(this);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            //PullToRefreshLayoutRenderer.Init();
            var cv = typeof(Xamarin.Forms.CarouselView);
            var assembly = Assembly.Load(cv.FullName); // https://blog.xamarin.com/flip-through-items-with-xamarin-forms-carouselview/
            app = new Core.App(new AndroidInitializer());
            LoadApplication(app);
        }

        public override void OnBackPressed()
        {
            if (app.CanGoBack)
            {
                base.OnBackPressed();
            }
        }

    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}


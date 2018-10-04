using Android.App;
using Android.Content.PM;
using Android.OS;
using App.Droid;
using Prism;
using Prism.Ioc;
using System.Reflection;

namespace App.Droid
{
    [Activity(Label = "App", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Stormlion.SNavigation.Droid.Platform.Init(this);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            var cv = typeof(Xamarin.Forms.CarouselView);
            var assembly = Assembly.Load(cv.FullName); // https://blog.xamarin.com/flip-through-items-with-xamarin-forms-carouselview/
            LoadApplication(new Core.App(new AndroidInitializer()));
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


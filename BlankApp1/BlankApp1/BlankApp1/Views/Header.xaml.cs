using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Header : ContentView
	{
		public Header ()
		{
			InitializeComponent ();
		}
        public void OnMenuTapped(object sender, EventArgs e)
        {
            //App.MenuIsPresented = true;

        }
        // On Logo tapped
        public void OnLogoTapped(object sender, EventArgs e)
        {
            //App.NavigationPage.Navigation.PushAsync(new MainPage());
           // App.MenuIsPresented = false;

        }
    }
}
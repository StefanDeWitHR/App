using Core.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class MenuPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public MenuPageViewModel(INavigationService navigationService):base(null)
        {
            _navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
           
        }
        async void NavigateAync(string page)
        {
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
            
        }

        // Authentication refers:
       // https://www.c-sharpcorner.com/blogs/how-to-make-autologin-for-your-xamarinforms-mobile-app
        // Login button enable switch > REPLACE soon with a static var
        private bool _IsLoggedIn;
        public bool IsLoggedIn
        {
            get { return _IsLoggedIn; }
            set
            {
                _IsLoggedIn = value;
                RaisePropertyChanged();
            }

        }
        private bool _IsLoggedOut;
        public bool IsLoggedOut
        {
            get { return _IsLoggedOut; }
            set
            {
                _IsLoggedOut = value;
                RaisePropertyChanged();
            }

        }



    }
}

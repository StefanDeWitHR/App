using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class LoginPageViewModel :   ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        // Commands
        public DelegateCommand<object> LoginCommand { get; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            Title = "LoginPage";      
            _navigationService = navigationService;
            _dialogService = dialogService;

            //Command Instances
            LoginCommand = new DelegateCommand<object>(Login);

        }

        // Properties
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                RaisePropertyChanged();
            }
        }


        public async void Login(object sender)
        {          
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username) )
            {
               await  _dialogService.DisplayAlertAsync("Gegevens onjuist", "Probeer opnieuw", "OK");
            }
            else
            {
                
            }
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Validators;
using FluentValidation.Results;


namespace Core.ViewModels
{
	public class TrialPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<object> RequestTrialCommand { get; }
       //  private DelegateCommand _command;
       // public DelegateCommand Command => _command ?? (_command = new DelegateCommand(Execute, CanExecute));

        //Validators
        private UserValidator validator = new UserValidator();

        public TrialPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
          
            RequestTrialCommand = new DelegateCommand<object>(SaveTrialData,ValidateTrialData);

            //Create an empty object
            User = new Users();
        }

        private async void SaveTrialData(object data)
        {

        }
        private bool ValidateTrialData(object arg)
        {
            ValidationResult result = validator.Validate(User);
            if (!result.IsValid)
            {
                return false;
            }
            return true;
        }

       
        private  Users _User;
        public Users User
        {
            get { return _User; }
            set { _User = value;
                  RaisePropertyChanged();
            }
        }

        // Binding for switch component
        private bool _IsFemale;
        public bool IsFemale
        {
            get { return _IsFemale; }
            set
            {
                _IsFemale = value;
                if (_IsFemale == true)
                    User.Gender = "Vrouw";
                    IsMale = false;
                RaisePropertyChanged();
            }
        }
        // Binding for switch component
        private bool _IsMale;
        public bool IsMale
        {
            get { return _IsMale; }
            set
            {
                _IsMale = value;
                if (_IsMale == true)
                    User.Gender = "Man";
                    IsFemale = false;
                RaisePropertyChanged();
            }
        }

    }
}

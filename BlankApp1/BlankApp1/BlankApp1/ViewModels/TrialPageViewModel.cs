using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Validators;
using FluentValidation.Results;
using Xamarin.Forms;


namespace Core.ViewModels
{
	public class TrialPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;


        public DelegateCommand RequestTrialCommand { get; private set; }


        //Validators
        private UserValidator validator = new UserValidator();

        public TrialPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            User = new Users();

            //Validation
            RequestTrialCommand = new DelegateCommand(SaveTrialData, ValidateTrialData);
            RequestTrialCommand.ObservesProperty(() => User.CompanyName);
            RequestTrialCommand.ObservesProperty(() => User.Email);
            RequestTrialCommand.ObservesProperty(() => User.FirstName);
            RequestTrialCommand.ObservesProperty(() => User.LastName);
            RequestTrialCommand.ObservesProperty(() => User.Gender);
            RequestTrialCommand.ObservesProperty(() => User.PhoneNumber);

        }

        private  void SaveTrialData()
        {
            // 
        }
        private bool ValidateTrialData()
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
            set
            {
                SetProperty(ref _User, value);
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
                {
                    User.Gender = "Vrouw";
                    IsMale = false;
                    
                }
                RaisePropertyChanged();
            }
        }
        private bool _IsMale;
        public bool IsMale
        {
            get { return _IsMale; }
            set
            {
                _IsMale = value;
                if (_IsMale == true)
                {
                    User.Gender = "Man";
                    IsFemale = false;
                    
                }
                RaisePropertyChanged();
            }
        }

    }
}

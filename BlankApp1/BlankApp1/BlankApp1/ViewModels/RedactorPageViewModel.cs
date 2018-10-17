using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Prism.Navigation;

namespace Core.ViewModels
{
	public class RedactorPageViewModel : ViewModelBase , INavigatedAware
	{
	    private readonly INavigationService _navigationService;
	    
        public RedactorPageViewModel(INavigationService navigationService) :base(navigationService)
        {
            _navigationService = navigationService;
           
        }

        // Init function
	    public async void OnNavigatedTo(INavigationParameters parameters)
        {
	      //  base.OnNavigatingTo(parameters);
	        if (parameters.ContainsKey("RedactorId"))
	        {
	            Title = (string) parameters["title"];
	            string UniqueId = (string) parameters["RedactorId"]; // replace to guid
                // Replace with function method in DAL
	            Redactor = new Redactors();
                Redactor.Name = "Nieuwsartikelen van " + UniqueId;
	        }
	    }
	    private Redactors _Redactor;
	    public Redactors Redactor
	    {
	        get { return _Redactor; }
	        set
	        {
	            _Redactor = value;
	            RaisePropertyChanged();
	        }
	    }

	    public void OnNavigatedFrom(INavigationParameters parameters)
	    {
	        throw new NotImplementedException();
	    }

	 
	}
}

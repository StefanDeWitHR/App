using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ViewModels
{
	public class TrialPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
    //    private readonly INewsArticlesService _newsArticlesService;

        public TrialPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
          //  _newsArticlesService = newsArticlesService;
        }
    }
}

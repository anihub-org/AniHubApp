using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        public SearchPageViewModel(INavigationService navigationService, IAniApiService aniApiService) : base(navigationService, aniApiService)
        {

        }
    }
}

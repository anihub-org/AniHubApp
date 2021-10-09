using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AniHubApp.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService, IAniApiService aniApiService) : base(navigationService, aniApiService)
        {

        }
    }
}

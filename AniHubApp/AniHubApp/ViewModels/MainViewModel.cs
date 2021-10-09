using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigationService navigationService, IAniApiService aniApiService) : base(navigationService, aniApiService)
        {

        }
    }
}

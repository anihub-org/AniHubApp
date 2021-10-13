using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.ViewModels
{
    public class AnimeDetailViewModel : BaseViewModel
    {
        public AnimeDetailViewModel(INavigationService navigationService, IAniApiService aniApiService) : base(navigationService)
        {

        }
    }
}

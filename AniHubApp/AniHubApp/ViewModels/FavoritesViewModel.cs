using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        public FavoritesViewModel(INavigationService navigationService, IAniApiService aniApiService) : base(navigationService, aniApiService)
        {

        }
    }
}

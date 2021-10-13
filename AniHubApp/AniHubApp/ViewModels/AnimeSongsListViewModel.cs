using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.ViewModels
{
    public class AnimeSongsListViewModel: BaseViewModel
    {
        public AnimeSongsListViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}

using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AniHubApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationService NavigationService { get; }
        protected IAniApiService AniApiService { get; }

        public BaseViewModel(INavigationService navigationService, IAniApiService aniApiService)
        {
            NavigationService = navigationService;
            AniApiService = aniApiService;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

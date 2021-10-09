using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AniHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; }
        private async void OnTap() => await NavigationService.NavigateAsync($"/{NavigationConstants.Paths.ContainerTabbedPage}");

        public MainViewModel(INavigationService navigationService, IAniApiService aniApiService) : base(navigationService, aniApiService)
        {
            TapCommand = new Command(OnTap);
        }
    }
}

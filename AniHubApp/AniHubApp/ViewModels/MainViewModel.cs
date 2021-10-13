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
        public ICommand NavigateToHomePageCommand { get; }
        private async void OnNavigation() => await NavigationService?.NavigateAsync($"/{NavigationConstants.Paths.ContainerTabbedPage}");

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToHomePageCommand = new Command(OnNavigation);
        }
    }
}

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
        private async void OnTap() => await _navigationService.NavigateAsync("/" + NavigationConstants.Paths.ContainerTabbedPage);

        INavigationService _navigationService;
        MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            TapCommand = new Command(OnTap);

        }
    }
}

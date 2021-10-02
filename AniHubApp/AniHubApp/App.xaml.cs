using AniHubApp.ViewModels;
using AniHubApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AniHubApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("Main?createTab=Home&createTab=Search&createTab=Favorites");
            //NavigationService.NavigateAsync("Main");
            NavigationService.NavigateAsync($"{NavigationConstants.Paths.Navigation}/{NavigationConstants.Paths.HomePage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(NavigationConstants.Paths.Navigation);
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(NavigationConstants.Paths.MainPage);
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>(NavigationConstants.Paths.HomePage);
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>(NavigationConstants.Paths.SearchPage);
            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesPageViewModel>(NavigationConstants.Paths.FavoritesPage);
        }

    }
}

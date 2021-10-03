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
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{NavigationConstants.Paths.MainPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>(NavigationConstants.Paths.MainPage);
            containerRegistry.RegisterForNavigation<HomePage>(NavigationConstants.Paths.HomePage);
            containerRegistry.RegisterForNavigation<SearchPage>(NavigationConstants.Paths.SearchPage);
            containerRegistry.RegisterForNavigation<FavoritesPage>(NavigationConstants.Paths.FavoritesPage);
        }

    }
}

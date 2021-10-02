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
            NavigationService.NavigateAsync("/Main");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>("Main");
            containerRegistry.RegisterForNavigation<HomePage>("Home");
            containerRegistry.RegisterForNavigation<SearchPage>("Search");
            containerRegistry.RegisterForNavigation<FavoritesPage>("Favorites");
        }

    }
}

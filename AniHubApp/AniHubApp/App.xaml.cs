using AniHubApp.Services;
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
            containerRegistry.RegisterForNavigation<NavigationPage>(NavigationConstants.Paths.Navigation);
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(NavigationConstants.Paths.MainPage);
            containerRegistry.RegisterForNavigation<ContainerTabbedPage>(NavigationConstants.Paths.ContainerTabbedPage);
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>(NavigationConstants.Paths.HomePage);
            containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>(NavigationConstants.Paths.SearchPage); 
            containerRegistry.RegisterForNavigation<SearchAnimeByGenrePage, SearchAnimeByGenreViewModel>(NavigationConstants.Paths.SearchAnimeByGenrePage);
            containerRegistry.RegisterForNavigation<SearchAnimeByNamePage, SearchAnimeByNameViewModel>(NavigationConstants.Paths.SearchAnimeByNamePage);
            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesViewModel>(NavigationConstants.Paths.FavoritesPage);
            containerRegistry.RegisterForNavigation<AnimeDetailPage, AnimeDetailViewModel>(NavigationConstants.Paths.AnimeDetailPage);
            containerRegistry.RegisterForNavigation<AnimeSongsListPage, AnimeSongsListViewModel>(NavigationConstants.Paths.AnimeSongListPage);


            containerRegistry.RegisterInstance<IAniApiService>(new AniApiService(new JsonSerializerService()));
        }
    }
}

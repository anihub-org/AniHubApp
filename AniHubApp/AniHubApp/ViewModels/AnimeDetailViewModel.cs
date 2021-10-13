using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AniHubApp.ViewModels
{
    public class AnimeDetailViewModel : BaseViewModel, INavigatedAware
    {
        public Anime Anime { get; set; }

        public ICommand NavigateToSongListCommand { get; set; }

        public AnimeDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToSongListCommand = new Command(OnNavigateToAnimeSongs);
        }

        public async void OnNavigateToAnimeSongs()
        {
            var parameters = new NavigationParameters
            {
                {"anime_id", Anime.AnimeID }
            };

            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.AnimeSongListPage}", parameters);
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Anime = parameters.GetValue<Anime>("anime");
        }
    }
}

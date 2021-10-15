using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using AniHubApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AniHubApp.ViewModels
{
    public class AnimeSongsListViewModel: BaseViewModel, INavigatedAware
    {
        public ObservableCollection<Song> AnimeSongs { get; set; }

        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;

        public ICommand RedirectToSpotifyCommand { get; set; }

        public AnimeSongsListViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IAniApiService aniApiService) : base(navigationService)
        {
            _aniApiService = aniApiService;
            _pageDialogService = pageDialogService;

            RedirectToSpotifyCommand = new Command<string>(OnRedirectToSpotify);
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var animeId = parameters.GetValue<string>("anime_id");

            GetSongsByAnimeID(animeId);
        }

        private async void GetSongsByAnimeID(string animeId)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var queryParams = new AnimeSongsListQueryParams(animeId: animeId);
            var response = await _aniApiService.GetAnimeSongsAsync(queryParams);

            AnimeSongs = new ObservableCollection<Song>(response.Data.Songs);
        }

        private async void OnRedirectToSpotify(string spotifyURL)
        {
            var spotifyURI = new Uri(spotifyURL);

            bool canRedirect = await _pageDialogService.DisplayAlertAsync("Info", "Are you sure you want to redirect to Spotify?", "Yes", "No");

            if (canRedirect)
            {
                await Browser.OpenAsync(spotifyURI, BrowserLaunchMode.SystemPreferred);
            }
        }

        private async void ShowNetworkConnectionError()
        {
            await _pageDialogService.DisplayAlertAsync("Error", "Missing network connection. Try again later", "Ok");
        }
    }
}

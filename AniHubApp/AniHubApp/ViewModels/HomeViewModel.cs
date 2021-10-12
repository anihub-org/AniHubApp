using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using System.Linq;
using Prism.Services;

namespace AniHubApp.ViewModels
{
    public class HomeViewModel : BaseViewModel, IInitialize
    {
        public const int BASE_POPULAR_ANIME_SCORE = 80;

        public ObservableCollection<Anime> PopularAnimes { get; set; }
        public ObservableCollection<Anime> SeasonalAnimes { get; set; }
        public ObservableCollection<Song> SongSuggestions { get; set; }

        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;

        public HomeViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;
        }

        public void Initialize(INavigationParameters parameters)
        {
            GetSeasonalAnimes();
            GetPopularAnimes();
            GetSongSuggestions();
        }

        private async void GetPopularAnimes()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var response = await _aniApiService.GetAnimesAsync();

            var popularAnimes = response.Data.Animes.Where(anime => anime.Score >= BASE_POPULAR_ANIME_SCORE);
            PopularAnimes = new ObservableCollection<Anime>(popularAnimes);
        }

        private async void GetSeasonalAnimes()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var queryParams = new AnimeListQueryParams(Season.GetCurrentSeasonValue());

            var response = await _aniApiService.GetAnimesAsync(queryParams);
           SeasonalAnimes = new ObservableCollection<Anime>(response.Data.Animes);
        }

        private async void GetSongSuggestions()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var queryParams = new AnimeSongsListQueryParams(Season.GetCurrentSeasonValue());

            var response = await _aniApiService.GetAnimeSongsAsync(queryParams);
            SongSuggestions = new ObservableCollection<Song>(response.Data.Songs);
        }

        private async void ShowNetworkConnectionError()
        {
            await _pageDialogService.DisplayAlertAsync("Error", "Missing network connection. Try again later", "Ok");
        }
    }
}

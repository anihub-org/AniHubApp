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
using System.Windows.Input;
using Xamarin.Forms;

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

        public ICommand NavigateToAnimeDetailCommand { get; set; }

        public HomeViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;

            NavigateToAnimeDetailCommand = new Command<Anime>(OnSelectedAnime);
        }

        public void Initialize(INavigationParameters parameters)
        {
            GetPopularAnimes();
            GetSeasonalAnimes();
            GetSongSuggestions();
        }

        private async void OnSelectedAnime(Anime anime)
        {
            var parameters = new NavigationParameters
            {
                {"anime", anime }
            };

            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.AnimeDetailPage}", parameters);
        }

        private async void GetPopularAnimes()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var response = await _aniApiService.GetAnimesAsync();

            var popularAnimes = response.Data.Animes.GetRange(0,10).Where(anime => anime.Score >= BASE_POPULAR_ANIME_SCORE);
            PopularAnimes = new ObservableCollection<Anime>(popularAnimes);
        }

        private async void GetSeasonalAnimes()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var queryParams = new AnimeListQueryParams(season: Season.GetCurrentSeasonValue());

            var response = await _aniApiService.GetAnimesAsync(queryParams);
           SeasonalAnimes = new ObservableCollection<Anime>(response.Data.Animes.GetRange(0, 10));
        }

        private async void GetSongSuggestions()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNetworkConnectionError();
                return;
            }

            var queryParams = new AnimeSongsListQueryParams(season: Season.GetCurrentSeasonValue());

            var response = await _aniApiService.GetAnimeSongsAsync(queryParams);
            SongSuggestions = new ObservableCollection<Song>(response.Data.Songs.GetRange(0, 10));
        }

        private async void ShowNetworkConnectionError()
        {
            await _pageDialogService.DisplayAlertAsync("Error", "Missing network connection. Try again later", "Ok");
        }
    }
}

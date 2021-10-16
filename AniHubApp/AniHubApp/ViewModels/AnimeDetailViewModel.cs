using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace AniHubApp.ViewModels
{
    public class AnimeDetailViewModel : BaseViewModel, INavigatedAware
    {
        public Anime Anime { get; set; }
        public Color IsFavoriteColor { get; set; } = Color.Gray;
        public Color IsFavoriteTextColor { get; set; } = Color.Black;
        public string IsFavoriteText { get; set; } = "Like";

        public ICommand NavigateToSongListCommand { get; set; }
        public ICommand FavoriteCommand { get; set; }
        public ICommand NavigateToAnimeSongsListCommand { get; set; }
        private JsonSerializerService _jsonSerializer { get; }

        public AnimeDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            FavoriteCommand = new Command(OnFavorite);
            _jsonSerializer = new JsonSerializerService();

            NavigateToAnimeSongsListCommand = new Command(OnNavigateToAnimeSongs);
        }

        public async void OnNavigateToAnimeSongs()
        {
            var parameters = new NavigationParameters
            {
                {"anime_id", Anime.AnimeID }
            };

            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.AnimeSongListPage}", parameters);
        }

        public void OnFavorite()
        {
            if (Anime.Favorite)
            {
                SaveFavoriteAnime(Anime, false);
                SetFavoriteButtonStyle(false);
            }
            else
            {
                SaveFavoriteAnime(Anime, true);
                SetFavoriteButtonStyle(true);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.New)
            {
                Anime = parameters.GetValue<Anime>("anime");

                if (IsAnimeLiked())
                {
                    SetFavoriteButtonStyle(true);
                }                
            }
        }

        private bool IsAnimeLiked()
        {
            var rawData = Preferences.Get($"anime:{Anime.AnimeID}", null);
            var anime = _jsonSerializer.Deserialize<Anime>(rawData);

            return anime.Favorite;
        }

        private void SetFavoriteButtonStyle(bool isFavorite)
        {
            if (isFavorite)
            {
                IsFavoriteColor = Color.Goldenrod;
                IsFavoriteTextColor = Color.White;
                IsFavoriteText = "Liked";

                return;
            }

            IsFavoriteColor = Color.LightGray;
            IsFavoriteTextColor = Color.Black;
            IsFavoriteText = "Like";
        }

        private void SaveFavoriteAnime(Anime anime, bool isFavorite)
        {
            var serializedData = Preferences.Get("favorites", "");
            var favoriteAnimes = _jsonSerializer.Deserialize<List<Anime>>(serializedData);

            if (favoriteAnimes == null)
            {
                favoriteAnimes = new List<Anime>();
            }

            if (isFavorite)
            {
                anime.Favorite = true;
                favoriteAnimes.Add(anime);
            }
            else
            {
                anime.Favorite = false;
                var selectedAnime = favoriteAnimes.Where(_anime => anime.AnimeID == _anime.AnimeID).First();
                favoriteAnimes.Remove(selectedAnime);
            }

            string payload = _jsonSerializer.SerializeObject(favoriteAnimes);
            Preferences.Set("favorites", payload);

            payload = _jsonSerializer.SerializeObject(anime);
            Preferences.Set($"anime:{anime.AnimeID}", payload);
        }
    }
}

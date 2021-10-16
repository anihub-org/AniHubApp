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

namespace AniHubApp.ViewModels
{
    public class AnimeDetailViewModel : BaseViewModel, INavigatedAware
    {
        public Anime Anime { get; set; }
        public Color IsFavoriteColor { get; set; } = Color.Gray;
        public Color IsFavoriteTextColor { get; set; } = Color.Black;
        public string IsFavoriteText { get; set; } = "Favorite";

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
                ChangeFavorite(Anime, false);
            }
            else
            {
                ChangeFavorite(Anime, true);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.New)
            {
                Anime = parameters.GetValue<Anime>("anime");
                if (Anime.Favorite)
                {
                    ChangeFavorite(Anime, true);
                }
            }
        }

        private void ChangeFavorite(Anime anime, bool isFavorite)
        {
            if (isFavorite)
            {
                anime.Favorite = true;
                IsFavoriteColor = Color.Goldenrod;
                IsFavoriteTextColor = Color.White;
                IsFavoriteText = "Favorited";

                var serializedData = Preferences.Get("favorites", null);
                var favoriteAnimes = _jsonSerializer.Deserialize<ObservableCollection<Anime>>(serializedData);

                if (favoriteAnimes == null)
                {
                    favoriteAnimes = new ObservableCollection<Anime>();
                }

                favoriteAnimes.Add(anime);

                string payload = _jsonSerializer.SerializeObject(favoriteAnimes);
                Preferences.Set("favorites", payload);
            }
            else
            {
                anime.Favorite = false;
                IsFavoriteColor = Color.LightGray;
                IsFavoriteTextColor = Color.Black;
                IsFavoriteText = "Favorite";

                var serializedData = Preferences.Get("favorites", null);
                var favoriteAnimes = _jsonSerializer.Deserialize<ObservableCollection<Anime>>(serializedData);

                if (favoriteAnimes == null)
                {
                    favoriteAnimes = new ObservableCollection<Anime>();
                }

                favoriteAnimes.Remove(anime);

                string payload = _jsonSerializer.SerializeObject(favoriteAnimes);
                Preferences.Set("favorites", payload);
            }
        }
    }
}

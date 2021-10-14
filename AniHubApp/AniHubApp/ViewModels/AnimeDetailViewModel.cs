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
        private JsonSerializerService _jsonSerializer { get; }

        public AnimeDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToSongListCommand = new Command(OnNavigateToAnimeSongs);
            FavoriteCommand = new Command(OnFavorite);
            _jsonSerializer = new JsonSerializerService();
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
                ChangeFavorite(false);
            }
            else
            {
                ChangeFavorite(true);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Anime = parameters.GetValue<Anime>("anime");
            if (Anime.Favorite)
            {
                ChangeFavorite(true);
            }
        }

        private void ChangeFavorite(bool isFavorite)
        {
            if (isFavorite)
            {
                Anime.Favorite = true;
                IsFavoriteColor = Color.Goldenrod;
                IsFavoriteTextColor = Color.White;
                IsFavoriteText = "Favorited";
                FavoritesViewModel.FavoriteAnimes.Add(Anime);
                string payload = _jsonSerializer.SerializeObject(FavoritesViewModel.FavoriteAnimes);
                Preferences.Set("favorites", payload);
            }
            else
            {
                Anime.Favorite = false;
                IsFavoriteColor = Color.LightGray;
                IsFavoriteTextColor = Color.Black;
                IsFavoriteText = "Favorite";
                FavoritesViewModel.FavoriteAnimes.Remove(Anime);
                string payload = _jsonSerializer.SerializeObject(FavoritesViewModel.FavoriteAnimes);
                Preferences.Set("favorites", payload);
            }
        }
    }
}

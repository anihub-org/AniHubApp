using AniHubApp.Models;
using AniHubApp.Services;
using Prism;
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
    public class FavoritesViewModel : BaseViewModel, IActiveAware, INavigationAware
    {
        public static ObservableCollection<Anime> FavoriteAnimes { get; set; } = new ObservableCollection<Anime>();
        public ICommand NavigateToAnimeDetailCommand { get; set; }
        private JsonSerializerService _jsonSerializer { get; set; }
        public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FavoritesViewModel(INavigationService navigationService) : base(navigationService)
        {
            _jsonSerializer = new JsonSerializerService();
            NavigateToAnimeDetailCommand = new Command<Anime>(OnSelectedAnime);
        }

        public event EventHandler IsActiveChanged;

        private async void OnSelectedAnime(Anime anime)
        {
            var parameters = new NavigationParameters
            {
                {"anime", anime }
            };

            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.AnimeDetailPage}", parameters);
        }
        protected virtual void RaiseIsActiveChanged()
        {
            var data = _jsonSerializer.Deserialize<ObservableCollection<Anime>>(Preferences.Get("favorites", null));
            foreach (var anime in data)
            {
                FavoriteAnimes.Add(anime);
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}

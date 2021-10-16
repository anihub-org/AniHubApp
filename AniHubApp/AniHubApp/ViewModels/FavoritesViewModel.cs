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
    public class FavoritesViewModel : BaseViewModel, IActiveAware
    {
        public ObservableCollection<Anime> FavoriteAnimes { get; set; }
        public ICommand NavigateToAnimeDetailCommand { get; set; }
        private IJsonSerializerService _jsonSerializer { get; set; }

        private bool _IsActive;
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
                if (value)
                {
                    RaiseIsActiveChanged();
                }
            }
        }

        public FavoritesViewModel(INavigationService navigationService, IJsonSerializerService jsonSerializerService) : base(navigationService)
        {
            _jsonSerializer = jsonSerializerService;
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
            var serializedData = Preferences.Get("favorites", "");

            var favoriteAnimeList = _jsonSerializer.Deserialize<List<Anime>>(serializedData);
            FavoriteAnimes = new ObservableCollection<Anime>(favoriteAnimeList);
        }
    }
}

using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AniHubApp.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<AnimeGenre> AnimeGenres { get; set; } = new ObservableCollection<AnimeGenre>()
        {
            new AnimeGenre("Action", "FullMetalAlchemistBrotherhood.jpg"),
            new AnimeGenre("Adventure", "OnePiece.jpg"),
            new AnimeGenre("Comedy", "Saiki.jpg"),
            new AnimeGenre("Fantasy", "TheSevenDeadlySins.jpg"),
            new AnimeGenre("Horror", "TokyoGhoul.jpg"),
            new AnimeGenre("Mecha", "CodeGeass.jpg"),
            new AnimeGenre("Music", "YourLieInApril.jpg"),
            new AnimeGenre("Slice Of Life", "Anohana.jpg"),
            new AnimeGenre("Sports", "Haikyu.jpg"),
            new AnimeGenre("Romance", "FruitsBasket.jpg")
        };

        private AnimeGenre _selectedAnimeGenre;
        public AnimeGenre SelectAnimeGenre
        {
            get
            {
                return _selectedAnimeGenre;
            }
            set
            {
                _selectedAnimeGenre = value;
                if (_selectedAnimeGenre != null)
                {
                    SelectedAnimeGenreCommand.Execute(_selectedAnimeGenre);
                }
            }
        }
        public ICommand SelectedAnimeGenreCommand { get; }
        public ICommand NavigateToSearchAnimeByName { get; }

        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;
        public SearchViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;
            SelectedAnimeGenreCommand = new Command<AnimeGenre>(OnAnimeGenreSelected);
            NavigateToSearchAnimeByName = new Command(OnSearchFrameSelected);
        }

        private async void OnSearchFrameSelected()
        {
            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.SearchAnimeByNamePage}");
        }

        private async void OnAnimeGenreSelected(AnimeGenre animeGenre)
        {
            var parameters = new NavigationParameters
            {
                {"genre", animeGenre }
            };

            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.SearchAnimeByGenrePage}", parameters);
        }
    }
}

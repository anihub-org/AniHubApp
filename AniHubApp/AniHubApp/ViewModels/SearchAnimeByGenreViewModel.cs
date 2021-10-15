using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace AniHubApp.ViewModels
{
    public class SearchAnimeByGenreViewModel : BaseViewModel, INavigatedAware
    {
        public ObservableCollection<Anime> AnimesByGenre { get; set; }
        public AnimeGenre AnimeSpecificGenre { get; set; }

        private Anime _selectedAnime;
        public Anime SelectAnime
        {
            get
            {
                return _selectedAnime;
            }
            set
            {
                _selectedAnime = value;
                if (_selectedAnime != null)
                {
                    SelectedAnimeCommand.Execute(_selectedAnime);
                }
            }
        }

        public ICommand SelectedAnimeCommand { get; }
        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;
        public SearchAnimeByGenreViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;
            SelectedAnimeCommand = new Command<Anime>(OnSelectedAnime);
        }

        private async void OnSelectedAnime(Anime anime)
        {
            var parameters = new NavigationParameters
            {
                {"anime", anime }
            };

            await NavigationService.NavigateAsync($"{NavigationConstants.Paths.AnimeDetailPage}", parameters);
        }

        private async void GetAnimesByGenres()
        {
            var queryParams = new AnimeListQueryParams(genre: AnimeSpecificGenre.Name);
            var response = await _aniApiService.GetAnimesAsync(queryParams);
            AnimesByGenre = new ObservableCollection<Anime>(response.Data.Animes);
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                AnimeSpecificGenre = parameters.GetValue<AnimeGenre>("genre");

                GetAnimesByGenres();
            }
        }
    }
}

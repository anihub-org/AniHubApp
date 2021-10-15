using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using Prism.Services;

namespace AniHubApp.ViewModels
{
    public class SearchAnimeByGenreViewModel : BaseViewModel, INavigatedAware
    {
        public ObservableCollection<Anime> AnimesByGenre { get; set; }
        public AnimeGenre AnimeSpecificGenre { get; set; }

        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;
        public SearchAnimeByGenreViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;
        }
        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            AnimeSpecificGenre = parameters.GetValue<AnimeGenre>("genre");
            var queryParams = new AnimeListQueryParams(genre: AnimeSpecificGenre.Name);
            var response = await _aniApiService.GetAnimesAsync(queryParams);
            AnimesByGenre = new ObservableCollection<Anime>(response.Data.Animes);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}

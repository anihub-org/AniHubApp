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
using Xamarin.Forms;

namespace AniHubApp.ViewModels
{
    public class SearchAnimeByNameViewModel : BaseViewModel
    {
        public ObservableCollection<Anime> AnimesByName { get; set; }
        public ICommand SearchCommand { get;  }

        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;
        public SearchAnimeByNameViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;
            SearchCommand = new Command<string>(OnSearchAnimeByName);
        }

        private async void OnSearchAnimeByName(string animeTitle)
        {
            var queryParams = new AnimeListQueryParams(title: animeTitle);
            var response = await _aniApiService.GetAnimesAsync(queryParams);
            AnimesByName = new ObservableCollection<Anime>(response.Data.Animes);
        }
    }
}

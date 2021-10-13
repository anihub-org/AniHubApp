using AniHubApp.Models;
using AniHubApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace AniHubApp.ViewModels
{
    public class SearchViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        private IAniApiService _aniApiService;
        private IPageDialogService _pageDialogService;
        public SearchViewModel(INavigationService navigationService, IAniApiService aniApiService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _aniApiService = aniApiService;
        }

        //public void Initialize(INavigationParameters parameters)
        //{
        //    AnimeGenres.Add("Action");
        //    AnimeGenres.Add("Adventure");
        //    AnimeGenres.Add("Comedy");
        //    AnimeGenres.Add("Fantasy");
        //    AnimeGenres.Add("Horror");
        //    AnimeGenres.Add("Mecha");
        //    AnimeGenres.Add("Music");
        //    AnimeGenres.Add("Slice Of Life");
        //    AnimeGenres.Add("Sports");
        //    AnimeGenres.Add("Romance");
        //}

        private async void ShowNetworkConnectionError()
        {
            await _pageDialogService.DisplayAlertAsync("Error", "Missing network connection. Try again later", "Ok");
        }
    }
}

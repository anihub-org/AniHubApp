﻿using AniHubApp.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AniHubApp.ViewModels
{
    class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Anime> Animes { get; } = new ObservableCollection<Anime>();

        HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Animes.Add(new Anime{Titles = new Titles{En="Test"}, CoverImage="https://64.media.tumblr.com/7207535226942d06e3f1f7eaf8b8b6cc/tumblr_nusthrNjZn1qkkg9mo1_1280.png" });
            Animes.Add(new Anime{Titles = new Titles{En="Test"}, CoverImage="https://64.media.tumblr.com/7207535226942d06e3f1f7eaf8b8b6cc/tumblr_nusthrNjZn1qkkg9mo1_1280.png" });
        }
    }
}
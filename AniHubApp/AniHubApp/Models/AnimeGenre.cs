using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AniHubApp.Models
{
    public class AnimeGenre : INotifyPropertyChanged
    {
        public AnimeGenre(string name, string coverImageURL)
        {
            Name = name;
            CoverImageURL = coverImageURL;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string CoverImageURL { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp
{
    public static class Configuration
    {
        public static class Urls
        {
            public const string BaseUrl = "https://api.aniapi.com";
            public const string AnimeList = "/v1/anime";
            public const string AnimeDetail = "/v1/anime/:id";
            public const string AnimeSongList = "/v1/song";
            public const string AnimeSongDetail = "/v1/song/:id";

        }
    }
}

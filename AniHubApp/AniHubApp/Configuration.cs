﻿using System;
using System.Collections.Generic;
using System.Text;
using Refit;

namespace AniHubApp
{
    public static class Configuration
    {
        public static class AniAPI
        {
            public const string BaseURL = "https://api.aniapi.com";
            public const string AnimeListPath = "/v1/anime";
            public const string AnimeDetailPath = "/v1/anime/{id}";
            public const string AnimeSongsListPath = "/v1/song";
            public const string AnimeSongDetailPath = "/v1/song/{id}";

            public class AnimeListQueryParams
            {
                [AliasAs("season")]
                public string SeasonPeriod { get; set; }
            }

            public class AnimeSongsListQueryParams
            {
                [AliasAs("anime_id")]
                public string AnimeId { get; set; }
            }
        }
    }
}

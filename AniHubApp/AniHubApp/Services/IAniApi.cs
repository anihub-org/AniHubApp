﻿using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static AniHubApp.Configuration;
using AniHubApp.Models;

namespace AniHubApp.Services
{
    public interface IAniApi
    {
        [Get("/" + AniAPI.BaseURL + AniAPI.AnimeListPath)]
        Task<HttpResponseMessage> GetAnimesAsync(AnimeListQueryParams queryParams);
        [Get("/" + AniAPI.BaseURL + AniAPI.AnimeDetailPath)]
        Task<HttpResponseMessage> GetAnimeByIdAsync([AliasAs("id")] int animeId);
        [Get("/" + AniAPI.BaseURL + AniAPI.AnimeSongsListPath)]
        Task<HttpResponseMessage> GetAnimeSongsAsync(AnimeSongsListQueryParams queryParams);
        [Get("/" + AniAPI.BaseURL + AniAPI.AnimeSongDetailPath)]
        Task<HttpResponseMessage> GetAnimeSongByIdAsync([AliasAs("id")] int animeSongId);
    }
}

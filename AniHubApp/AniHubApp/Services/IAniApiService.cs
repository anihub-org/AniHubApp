using AniHubApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AniHubApp.Configuration;

namespace AniHubApp.Services
{
    public interface IAniApiService
    {
        Task<AnimeListResponse> GetAnimesAsync(AniAPI.AnimeListQueryParams queryParams = null);
        Task<AnimeResponse> GetAnimeByIdAsync(int animeId);
        Task<SongListResponse> GetAnimeSongsAsync(AniAPI.AnimeSongsListQueryParams = null);
        Task<SongResponse> GetAnimeSongByIdAsync(int animeSongId);
    }
}

using AniHubApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AniHubApp.Configuration;
using AniHubApp.Models;

namespace AniHubApp.Services
{
    public interface IAniApiService
    {
        Task<AnimeListResponse> GetAnimesAsync(AnimeListQueryParams queryParams = null);
        Task<AnimeResponse> GetAnimeByIdAsync(int animeId);
        Task<SongListResponse> GetAnimeSongsAsync(AnimeSongsListQueryParams queryParams = null);
        Task<SongResponse> GetAnimeSongByIdAsync(int animeSongId);
    }
}

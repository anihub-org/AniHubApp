using AniHubApp.Models;
using System.Threading.Tasks;

namespace AniHubApp.Services
{
    public interface IAniApiService
    {
        Task<AnimeListResponse> GetAnimesAsync();
        Task<AnimeResponse> GetAnimeByIdAsync(int animeId);
        Task<SongListResponse> GetAnimeSongsAsync(AnimeSongsListQueryParams queryParams = null);
        Task<SongResponse> GetAnimeSongByIdAsync(int animeSongId);
    }
}

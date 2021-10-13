using Refit;
using System.Net.Http;
using System.Threading.Tasks;
using static AniHubApp.Configuration.AniAPI;
using AniHubApp.Models;

namespace AniHubApp.Services
{
    public interface IAniApi
    {
        [Get(AnimeListPath)]
        Task<HttpResponseMessage> GetAnimesAsync([Query]AnimeListQueryParams queryParams);
        [Get(AnimeDetailPath)]
        Task<HttpResponseMessage> GetAnimeByIdAsync([AliasAs("id")] int animeId);
        [Get(AnimeSongsListPath)]
        Task<HttpResponseMessage> GetAnimeSongsAsync([Query]AnimeSongsListQueryParams queryParams);
        [Get(AnimeSongDetailPath)]
        Task<HttpResponseMessage> GetAnimeSongByIdAsync([AliasAs("id")] int animeSongId);
    }
}

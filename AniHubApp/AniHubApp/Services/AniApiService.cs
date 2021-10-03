using AniHubApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AniHubApp.Configuration;

namespace AniHubApp.Services
{
    public class AniApiService: IAniApiService
    {
        private IAniApi _aniApi;

        private IJsonSerializerService serializer = new JsonSerializerService();

        public AniApiService()
        {
            _aniApi = RestService.For<IAniApi>(AniAPI.BaseURL);
        }

        public async Task<AnimeResponse> GetAnimeByIdAsync(int animeId)
        {
            var response = await _aniApi.GetAnimeByIdAsync(animeId);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeResponse = serializer.Deserialize<AnimeResponse>(responseString);

                return animeResponse;
            }

            return null;
        }

        public async Task<AnimeListResponse> GetAnimesAsync(AniAPI.AnimeListQueryParams queryParams = null)
        {
            var response = await _aniApi.GetAnimesAsync(queryParams);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeListResponse = serializer.Deserialize<AnimeListResponse>(responseString);

                return animeListResponse;
            }

            return null;
        }

        public async Task<SongResponse> GetAnimeSongByIdAsync(int animeSongId)
        {
            var response = await _aniApi.GetAnimeSongByIdAsync(animeSongId);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeSongResponse = serializer.Deserialize<SongResponse>(responseString);

                return animeSongResponse;
            }

            return null;
        }

        public async Task<SongListResponse> GetAnimeSongsAsync(AniAPI.AnimeSongsListQueryParams queryParams = null)
        {
            var response = await _aniApi.GetAnimeSongsAsync(queryParams);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeSongsListResponse = serializer.Deserialize<SongListResponse>(responseString);

                return animeSongsListResponse;
            }

            return null;
        }
    }
}

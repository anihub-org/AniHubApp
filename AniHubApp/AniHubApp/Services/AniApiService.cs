using AniHubApp.Models;
using MonkeyCache.FileStore;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static AniHubApp.Configuration;

namespace AniHubApp.Services
{
    public class AniApiService: IAniApiService
    {
        private IAniApi _aniApi;
        private IJsonSerializerService _serializer;

        public AniApiService(IJsonSerializerService jsonSerializerService)
        {
            _serializer = jsonSerializerService;
            _aniApi = RestService.For<IAniApi>(AniAPI.BaseURL);
        }

        public async Task<AnimeResponse> GetAnimeByIdAsync(int animeId)
        {
            var response = await _aniApi.GetAnimeByIdAsync(animeId);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeResponse = _serializer.Deserialize<AnimeResponse>(responseString);

                return animeResponse;
            }

            return null;
        }

        public async Task<AnimeListResponse> GetAnimesAsync(AnimeListQueryParams queryParams = null)
        {
            var response = await _aniApi.GetAnimesAsync(queryParams);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeListResponse = _serializer.Deserialize<AnimeListResponse>(responseString);

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

                var animeSongResponse = _serializer.Deserialize<SongResponse>(responseString);

                return animeSongResponse;
            }

            return null;
        }

        public async Task<SongListResponse> GetAnimeSongsAsync(AnimeSongsListQueryParams queryParams = null)
        {
            var response = await _aniApi.GetAnimeSongsAsync(queryParams);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var animeSongsListResponse = _serializer.Deserialize<SongListResponse>(responseString);

                return animeSongsListResponse;
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class AnimeListResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public AnimeData Data { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class AnimeData
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("documents")]
        public List<Anime> Animes { get; set; }
        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }
    }
}

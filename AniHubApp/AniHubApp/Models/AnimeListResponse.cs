using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class AnimeListResponse
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public AnimeData Data { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class AnimeData
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("documents")]
        public List<Anime> Animes { get; set; }
        [JsonProperty("last_page")]
        public int LastPage { get; set; }
    }
}

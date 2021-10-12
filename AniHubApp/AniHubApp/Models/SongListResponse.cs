using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class SongListResponse
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public SongData Data { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class SongData
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("documents")]
        public List<Song> Songs { get; set; }
        [JsonProperty("last_page")]
        public int LastPage { get; set; }
    }
}

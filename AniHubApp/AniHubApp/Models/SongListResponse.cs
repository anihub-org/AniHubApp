using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class SongListResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public SongData Data { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class SongData
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("documents")]
        public List<Song> Songs { get; set; }
        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }
    }
}

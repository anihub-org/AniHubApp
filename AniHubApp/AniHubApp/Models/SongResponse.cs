using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class SongResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; }
        [JsonPropertyName("message")]
        public string Message { get; }
        [JsonPropertyName("data")]
        public Song Data { get; }
        [JsonPropertyName("version")]
        public string Version { get; }
    }

    public class Song
    {
        [JsonPropertyName("id")]
        public int ID { get; }
        [JsonPropertyName("anime_id")]
        public int AnimeID { get; }
        [JsonPropertyName("title")]
        public string Title { get; }
        [JsonPropertyName("artist")]
        public string Artist { get; }
        [JsonPropertyName("album")]
        public string Album { get; }
        [JsonPropertyName("year")]
        public int Year { get; }
        [JsonPropertyName("season")]
        public int Season { get; }
        [JsonPropertyName("duration")]
        public string DurationInMilliseconds { get; }
        [JsonPropertyName("preview_url")]
        public string PreviewURL { get; }
        [JsonPropertyName("open_spotify_url")]
        public string OpenSpotifyURL { get; }
        [JsonPropertyName("local_spotify_url")]
        public string LocalSpotifyURL { get; }
        [JsonPropertyName("type")]
        public string Type { get; }
    }
}

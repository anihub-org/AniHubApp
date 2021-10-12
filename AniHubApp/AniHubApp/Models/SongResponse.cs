using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class SongResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public Song Data { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class Song
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("anime_id")]
        public int AnimeID { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("artist")]
        public string Artist { get; set; }
        [JsonPropertyName("album")]
        public string Album { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("season")]
        public int Season { get; set; }
        [JsonPropertyName("duration")]
        public string DurationInMilliseconds { get; set; }
        [JsonPropertyName("preview_url")]
        public string PreviewURL { get; set; }
        [JsonPropertyName("open_spotify_url")]
        public string OpenSpotifyURL { get; set; }
        [JsonPropertyName("local_spotify_url")]
        public string LocalSpotifyURL { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}

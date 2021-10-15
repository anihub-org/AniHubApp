using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class SongResponse
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Song Data { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class Song
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("anime_id")]
        public int AnimeID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("artist")]
        public string Artist { get; set; }
        [JsonProperty("album")]
        public string Album { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("season")]
        public int Season { get; set; }
        [JsonProperty("duration")]
        public int DurationInMilliseconds { get; set; }
        [JsonProperty("preview_url")]
        public string PreviewURL { get; set; }
        [JsonProperty("open_spotify_url")]
        public string OpenSpotifyURL { get; set; }
        [JsonProperty("local_spotify_url")]
        public string LocalSpotifyURL { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

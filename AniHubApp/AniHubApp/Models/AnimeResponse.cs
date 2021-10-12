using System;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class AnimeResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public Anime Data { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class Anime
    {
        [JsonPropertyName("id")]
        public int AnimeID { get; set; }
        [JsonPropertyName("anilist_id")]
        public int AnilistID { get; set; }
        [JsonPropertyName("mal_id")]
        public int MyAnimeListID { get; set; }
        [JsonPropertyName("format")]
        public int Format { get; set; }
        [JsonPropertyName("titles")]
        public Titles Titles { get; set; }
        [JsonPropertyName("descriptions")]
        public Descriptions Descriptions { get; set; }
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("season_period")]
        public int SeasonPeriod { get; set; }
        [JsonPropertyName("season_year")]
        public int SeasonYear { get; set; }
        [JsonPropertyName("episodes_count")]
        public int EpisodesCount { get; set; }
        [JsonPropertyName("episode_duration")]
        public int EpisodeDuration { get; set; }
        [JsonPropertyName("cover_image")]
        public string CoverImageURL { get; set; }
        [JsonPropertyName("cover_color")]
        public string CoverHexColor { get; set; }
        [JsonPropertyName("banner_image")]
        public string BannerImageURL { get; set; }
        [JsonPropertyName("genres")]
        public string[] Genres { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }

    public class Titles
    {
        [JsonPropertyName("en")]
        public string English { get; set; }
        [JsonPropertyName("jp")]
        public string Japanese { get; set; }
        [JsonPropertyName("it")]
        public string Italian { get; set; }
    }

    public class Descriptions
    {
        [JsonPropertyName("en")]
        public string English { get; set; }
        [JsonPropertyName("it")]
        public string Italian { get; set; }
    }
}

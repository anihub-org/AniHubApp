using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class AnimeResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; }
        [JsonPropertyName("message")]
        public string Message { get; }
        [JsonPropertyName("data")]
        public Anime Data { get; }
        [JsonPropertyName("version")]
        public string Version { get; }
    }

    public class Anime
    {
        [JsonPropertyName("id")]
        public int AnimeID { get; }
        [JsonPropertyName("anilist_id")]
        public int AnilistID { get; }
        [JsonPropertyName("mal_id")]
        public int MyAnimeListID { get; }
        [JsonPropertyName("format")]
        public int Format { get; }
        [JsonPropertyName("titles")]
        public Titles Titles { get; }
        [JsonPropertyName("descriptions")]
        public Descriptions Descriptions { get; }
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; }
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; }
        [JsonPropertyName("season_period")]
        public int SeasonPeriod { get; }
        [JsonPropertyName("season_year")]
        public int SeasonYear { get; }
        [JsonPropertyName("episodes_count")]
        public int EpisodesCount { get; }
        [JsonPropertyName("episode_duration")]
        public int EpisodeDuration { get; }
        [JsonPropertyName("cover_image")]
        public string CoverImageURL { get; }
        [JsonPropertyName("cover_color")]
        public string CoverHexColor { get; }
        [JsonPropertyName("banner_image")]
        public string BannerImageURL { get; }
        [JsonPropertyName("genres")]
        public string[] Genres { get; }
        [JsonPropertyName("score")]
        public int Score { get; }
    }

    public class Titles
    {
        [JsonPropertyName("en")]
        public string English { get; }
        [JsonPropertyName("jp")]
        public string Japanese { get; }
        [JsonPropertyName("it")]
        public string Italian { get; }
    }

    public class Descriptions
    {
        [JsonPropertyName("en")]
        public string English { get; }
        [JsonPropertyName("it")]
        public string Italian { get; }
    }
}

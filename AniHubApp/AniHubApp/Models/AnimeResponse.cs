using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AniHubApp.Models
{
    public class AnimeResponse
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Anime Data { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class Anime
    {
        [JsonProperty("id")]
        public int AnimeID { get; set; }
        [JsonProperty("anilist_id")]
        public int AnilistID { get; set; }
        [JsonProperty("mal_id")]
        public int MyAnimeListID { get; set; }
        [JsonProperty("format")]
        public int Format { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("titles")]
        public Titles Titles { get; set; }
        [JsonProperty("descriptions")]
        public Descriptions Descriptions { get; set; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("season_period")]
        public int SeasonPeriod { get; set; }
        [JsonProperty("season_year")]
        public int SeasonYear { get; set; }
        [JsonProperty("episodes_count")]
        public int EpisodesCount { get; set; }
        [JsonProperty("episode_duration")]
        public int EpisodeDuration { get; set; }
        [JsonProperty("cover_image")]
        public string CoverImageURL { get; set; }
        [JsonProperty("cover_color")]
        public string CoverHexColor { get; set; }
        [JsonProperty("banner_image")]
        public string BannerImageURL { get; set; }
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
    }

    public class Titles
    {
        [JsonProperty("en")]
        public string English { get; set; }
    }

    public class Descriptions
    {
        [JsonProperty("en")]
        public string English { get; set; }
        [JsonProperty("it")]
        public string Italian { get; set; }
    }
}

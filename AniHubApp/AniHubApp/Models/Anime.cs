using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AniHubApp.Models
{
    public class Anime
    {
        [JsonProperty("anilist_id")]
        public int AnilistId { get; set; }

        [JsonProperty("mal_id")]
        public int MalId { get; set; }

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

        [JsonProperty("trailer_url")]
        public string TrailerUrl { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }

        [JsonProperty("cover_color")]
        public string CoverColor { get; set; }

        [JsonProperty("banner_image")]
        public string BannerImage { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("prequel")]
        public int? Prequel { get; set; }

        [JsonProperty("sequel")]
        public int? Sequel { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AniHubApp.Models
{
    public class AnimeListResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; }
        [JsonPropertyName("message")]
        public string Message { get; }
        [JsonPropertyName("data")]
        public AnimeData Data { get; }
        [JsonPropertyName("version")]
        public string Version { get; }
    }

    public class AnimeData
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; }
        [JsonPropertyName("count")]
        public int Count { get; }
        [JsonPropertyName("documents")]
        public List<Anime> Animes { get; }
        [JsonPropertyName("last_page")]
        public int LastPage { get; }
    }
}

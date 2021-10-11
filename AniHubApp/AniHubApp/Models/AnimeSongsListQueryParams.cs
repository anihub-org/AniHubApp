using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Models
{
    public class AnimeSongsListQueryParams
    {
        [AliasAs("anime_id")]
        public string AnimeId { get; set; }
    }
}

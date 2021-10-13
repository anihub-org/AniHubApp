using Refit;

namespace AniHubApp.Models
{
    public class AnimeSongsListQueryParams
    {
        public AnimeSongsListQueryParams(int? season = null, string animeId = null)
        {
            SeasonPeriod = season;
            AnimeId = animeId;
        }

        [AliasAs("anime_id")]
        public string AnimeId { get; }
        [AliasAs("season")]
        public int? SeasonPeriod { get; }
    }
}

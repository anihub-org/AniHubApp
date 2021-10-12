using Refit;

namespace AniHubApp.Models
{
    public class AnimeSongsListQueryParams
    {
        public AnimeSongsListQueryParams(int season)
        {
            SeasonPeriod = season;
        }

        public AnimeSongsListQueryParams(string animeId = null)
        {
            AnimeId = animeId;
        }

        [AliasAs("anime_id")]
        public string AnimeId { get; }
        [AliasAs("season")]
        public int SeasonPeriod { get; }
    }
}

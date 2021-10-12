using Refit;

namespace AniHubApp.Models
{
    public class AnimeListQueryParams
    {
        public AnimeListQueryParams() { }

        public AnimeListQueryParams(int season)
        {
            SeasonPeriod = season;
        }

        [AliasAs("season")]
        public int SeasonPeriod { get; }
    }
}

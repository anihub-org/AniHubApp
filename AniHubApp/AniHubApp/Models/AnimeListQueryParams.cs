using Refit;

namespace AniHubApp.Models
{
    public class AnimeListQueryParams
    {
        public AnimeListQueryParams() { }

        public AnimeListQueryParams(int? season = null, string genre = null)
        {
            SeasonPeriod = season;
            Genre = genre;
        }

        [AliasAs("season")]
        public int? SeasonPeriod { get; }
        [AliasAs("genres")]
        public string Genre { get; }
    }
}

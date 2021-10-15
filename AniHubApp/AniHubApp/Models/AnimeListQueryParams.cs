using Refit;

namespace AniHubApp.Models
{
    public class AnimeListQueryParams
    {
        public AnimeListQueryParams() { }

        public AnimeListQueryParams(int? season = null, string genre = null, string title = null)
        {
            SeasonPeriod = season;
            Genre = genre;
            Title = title;
        }

        [AliasAs("season")]
        public int? SeasonPeriod { get; }
        [AliasAs("genres")]
        public string Genre { get; }
        [AliasAs("title")]
        public string Title { get; }
    }
}

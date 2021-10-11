using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Models
{
    public class AnimeListQueryParams
    {
        public AnimeListQueryParams(int season)
        {
            SeasonPeriod = season;
        }

        [AliasAs("season")]
        public int SeasonPeriod { get; }
    }
}

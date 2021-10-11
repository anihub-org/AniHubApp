using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Models
{
    public class AnimeListQueryParams
    {
        [AliasAs("season")]
        public string SeasonPeriod { get; set; }
    }
}

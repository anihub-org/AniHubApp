using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Models
{

    public class Data
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("documents")]
        public List<Anime> Animes { get; set; }

        [JsonProperty("last_page")]
        public int LastPage { get; set; }
    }
}

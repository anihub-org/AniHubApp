using Newtonsoft.Json;

namespace AniHubApp.Models
{
    public class Titles
    {
        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("jp")]
        public string Jp { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }
    }
}

using Newtonsoft.Json;

namespace AniHubApp.Models
{
    public class Descriptions
    {
        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }
    }
}

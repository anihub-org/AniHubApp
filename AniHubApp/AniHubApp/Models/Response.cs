using Newtonsoft.Json;

namespace AniHubApp.Models
{
    public class Response
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}

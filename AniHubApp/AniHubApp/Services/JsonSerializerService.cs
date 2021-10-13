using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;


namespace AniHubApp.Services
{
    public class JsonSerializerService: IJsonSerializerService
    {
        public string SerializeObject<T> (T payload)
        {
            return JsonConvert.SerializeObject(payload);
        }

        public T Deserialize<T> (string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload);
        }
    }
}

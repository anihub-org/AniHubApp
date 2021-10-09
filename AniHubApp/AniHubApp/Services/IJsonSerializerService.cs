using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Services
{
    public interface IJsonSerializerService
    {
        string SerializeObject<T>(T payload);
        T Deserialize<T>(string payload);
    }
}

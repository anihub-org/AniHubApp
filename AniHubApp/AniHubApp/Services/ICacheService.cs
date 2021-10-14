using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Services
{
    public interface ICacheService
    {
        void Add<T>(string key, T data, TimeSpan expiresIn);
        T Get<T>(string key);
        bool IsExpired(string key);
        bool Exists(string key);
        bool IsKeyValid(string key);
    }
}

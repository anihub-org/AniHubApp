using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Services
{
    public class CacheService : ICacheService
    {
        public CacheService()
        {
            Barrel.ApplicationId = Configuration.CacheApplicationId;
        }

        public void Add<T>(string key, T data, TimeSpan expiresIn)
        {
            Barrel.Current.Add(key, data, expiresIn);
        }

        public T Get<T>(string key)
        {
            return Barrel.Current.Get<T>(key);
        }

        public bool IsExpired(string key)
        {
            return Barrel.Current.IsExpired(key);
        }

        public bool Exists(string key)
        {
            return Barrel.Current.Exists(key);
        }

        public bool IsKeyValid(string key)
        {
            return !IsExpired(key) && Exists(key);
        }
    }
}

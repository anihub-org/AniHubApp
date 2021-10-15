using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Services
{
    public static class Helper
    {
        private const string BASE_CACHE_KEY = "AniHubApp";

        public static string GenerateCacheKey(string identifier)
        {
            return $"{BASE_CACHE_KEY}:{identifier}";
        }
    }
}

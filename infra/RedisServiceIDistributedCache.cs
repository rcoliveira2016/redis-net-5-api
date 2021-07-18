using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace redis_net_5_api.infra
{
    public class RedisServiceIDistributedCache: IRedisService
    {
        private const int timeCacheSeconds = 3600;
        private readonly IDistributedCache _distributedCache;
        public RedisServiceIDistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task SetStringAsync<T>(
            string key,
            string value,
            int? timeCacheSeconds) where T : class
        {
            if (value is null) return;
            await _distributedCache.SetStringAsync(key, value, getCacheEntryOptions(timeCacheSeconds));
        }

        public async Task SetAsync<T>(string key, T value, int? timeCacheSeconds) where T : class
        {
            if (value is null) return;
            var valorJson = JsonSerializer.SerializeToUtf8Bytes<T>(value);
            await _distributedCache.SetAsync(
                key, 
                valorJson, 
                getCacheEntryOptions(timeCacheSeconds));
        }

        public async Task<T> GetAsync<T>(string key) where T: class
        {
            var value = await _distributedCache.GetAsync(key);
            if (value is null) return null;
            return JsonSerializer.Deserialize<T>(value);
        }


        private DistributedCacheEntryOptions getCacheEntryOptions(int? timeCacheSeconds)
        {
            return new()
            {
                AbsoluteExpirationRelativeToNow = 
                    TimeSpan.FromSeconds(timeCacheSeconds ?? RedisServiceIDistributedCache.timeCacheSeconds),
            };
        }
    }
}

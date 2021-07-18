using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
//https://renatogroffe.medium.com/net-core-3-1-redis-do-cache-distribu%C3%ADdo-ao-uso-como-banco-nosql-a88d6da39e0
namespace redis_net_5_api.infra
{
    public class RedisServiceStackExchangeRedis : IRedisService
    {
        private const int timeCacheSeconds = 3600;
        private readonly string connectionStrings;
        public RedisServiceStackExchangeRedis(IConfiguration config)
        {
            connectionStrings = config.GetConnectionString("Redis");
        }

        public async Task SetStringAsync<T>(
            string key,
            string value,
            int? timeCacheSeconds) where T : class
        {
            if (value is null) return;
            await OpenConecton(async db => {
                await db.StringSetAsync(key, value, expiry: GetTimeSpamCahce(timeCacheSeconds));
            });
        }

        public async Task SetAsync<T>(string key, T value, int? timeCacheSeconds) where T : class
        {
            if (value is null) return;
            await OpenConecton(async db => { 
                var valorJson = JsonSerializer.Serialize(value);
                await db.StringSetAsync(key, valorJson, expiry: GetTimeSpamCahce(timeCacheSeconds));
            });
        }

        private TimeSpan? GetTimeSpamCahce(int? timeCacheSeconds)
        {
            return TimeSpan.FromSeconds(timeCacheSeconds?? RedisServiceStackExchangeRedis.timeCacheSeconds);
        }

        public async Task<T> GetAsync<T>(string key) where T: class
        {
            return await OpenConectonReturnValue<T>(async db => {
                var value = await db.StringGetAsync(key);
                if (!value.HasValue) return null;

                return JsonSerializer.Deserialize<T>(value.ToString());
            });
        }

        private async Task OpenConecton(Func<IDatabase, Task> action)
        {
            using (var conexaoRedis = ConnectionMultiplexer.Connect(connectionStrings))
            {
                await action?.Invoke(conexaoRedis.GetDatabase());
            }
        }

        private Task<T> OpenConectonReturnValue<T>(Func<IDatabase, Task<T>> action)
        {
            using (var conexaoRedis = ConnectionMultiplexer.Connect(connectionStrings))
            {
                return action.Invoke(conexaoRedis.GetDatabase());
            }
        }
    }
}

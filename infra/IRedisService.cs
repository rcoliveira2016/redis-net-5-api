using System.Threading.Tasks;

namespace redis_net_5_api.infra
{
    public interface IRedisService
    {
        Task<T> GetAsync<T>(string key) where T : class;
        Task SetAsync<T>(string key, T value, int? timeCacheSeconds) where T : class;
        Task SetStringAsync<T>(string key, string value, int? timeCacheSeconds) where T : class;
    }
}
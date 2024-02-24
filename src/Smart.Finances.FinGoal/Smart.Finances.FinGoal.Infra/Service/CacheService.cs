using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Infra.Service;

public class CacheService(IDistributedCache cache) : ICacheService
{
    private readonly IDistributedCache _cache = cache;

    public Task Set<T>(string key, T value)
    {
        return _cache.SetStringAsync(key, JsonSerializer.Serialize(value));
    }

    public async Task<T?> Get<T>(string key)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(await _cache.GetAsync(key));
        }
        catch
        {
            return default;
        }
    }
}
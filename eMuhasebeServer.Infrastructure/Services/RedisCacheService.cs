using System.Text.Json;
using eMuhasebeServer.Application.Services;
using StackExchange.Redis;

namespace eMuhasebeServer.Infrastructure.Services;

public sealed class RedisCacheService : ICacheService
{
    private readonly IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public T? Get<T>(string key)
    {
        var value = _database.StringGet(key);
        return value.HasValue ? JsonSerializer.Deserialize<T?>(value.ToString()) : default;
    }

    public void Set<T>(string key, T value, TimeSpan? expire = null)
    {
        _database.StringSet(key, JsonSerializer.Serialize(value), expire);
    }

    public bool Remove(string key)
    {
        return _database.KeyDelete(key);
    }
}
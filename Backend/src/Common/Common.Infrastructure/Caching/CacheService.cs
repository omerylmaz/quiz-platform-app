using System.Text.Json;
using Common.Application.Caching;
using StackExchange.Redis;

namespace Common.Infrastructure.Caching;

internal sealed class CacheService : ICacheService
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public CacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _database = _connectionMultiplexer.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        if (!_connectionMultiplexer.IsConnected)
            return default;

        RedisValue data = await _database.StringGetAsync(key);
        if (data.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T?>(data!);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = default)
    {
        if (!_connectionMultiplexer.IsConnected)
            return;

        string data = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, data, expiration);
    }

    public async Task RemoveAsync(string key)
    {
        if (!_connectionMultiplexer.IsConnected)
            return;

        await _database.KeyDeleteAsync(key);
    }

    public async Task RemoveByPatternAsync(string pattern)
    {
        if (!_connectionMultiplexer.IsConnected)
            return;

        IServer server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints()[0]);
        RedisKey[] keys = server.Keys(pattern: $"{pattern}*").ToArray();

        foreach (RedisKey key in keys)
            await _database.KeyDeleteAsync(key);
    }
}

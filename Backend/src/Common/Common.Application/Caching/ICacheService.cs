namespace Common.Application.Caching;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = default);
    Task RemoveAsync(string key);
    Task RemoveByPatternAsync(string pattern);
}

namespace Application.Abstractions.Caching;

public interface ICacheService
{
    Task<T> GetOrCreatAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default);
}
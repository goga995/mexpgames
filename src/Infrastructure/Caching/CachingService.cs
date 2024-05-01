using Application.Abstractions.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

public class CachingService : ICacheService
{
    private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(5);
    //Ovde smo mogli da koristimo bilo koji drugi distributed cache (redis ...)
    private readonly IMemoryCache _memoryCache;

    public CachingService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<T> GetOrCreatAsync<T>(string key,
                                            Func<CancellationToken, Task<T>> factory,
                                            TimeSpan? expiration = null,
                                            CancellationToken cancellationToken = default)
    {
        T result = await _memoryCache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(expiration ?? DefaultExpiration);

            return factory(cancellationToken);
        });

        return result;
    }
}
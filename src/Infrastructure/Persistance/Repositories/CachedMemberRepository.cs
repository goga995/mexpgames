using Domain.Game;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistance.Repositories;

public class CachedMemberRepository : IGameRepository
{
    private readonly IGameRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedMemberRepository([FromKeyedServices("og")] IGameRepository decorated,
     IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public void AddGame(Game game)
    {
        _decorated.AddGame(game);
    }

    public void Delete(Game game)
    {
        _decorated.Delete(game);
    }

    public async Task<List<GameResponse>> GetAllAsync()
    {
        return await _decorated.GetAllAsync();
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        string key = $"game-{id}";
        return await _memoryCache.GetOrCreateAsync(
            key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return await _decorated.GetByIdAsync(id);
            });
    }

    public async Task<Game?> Scrape(string SteamGameID)
    {
        return await _decorated.Scrape(SteamGameID);
    }

    public void Update(Game game)
    {
        _decorated.Update(game);
    }
}
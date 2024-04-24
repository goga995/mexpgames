using Domain.Game;
using Infrastructure.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddGame(Game game)
    {
        _context.Games.Add(game);
    }

    public void Delete(Game game)
    {
        _context.Games.Remove(game);
    }

    public async Task<List<GameResponse>> GetAllAsync()
    {
        IQueryable<Game> query = _context.Games;
        var tmp = await query.ToListAsync();
        var response = tmp.Select(g => new GameResponse(
            g.Id,
            g.Name,
            g.CreatorName,
            g.ReleseDate,
            g.GameType,
            g.Rating,
            g.ImageLinks,
            g.Description
        ));
        return (List<GameResponse>)response;
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _context.Games.FindAsync(id);
    }

    public void Update(Game game)
    {
        _context.Games.Update(game);
    }
}
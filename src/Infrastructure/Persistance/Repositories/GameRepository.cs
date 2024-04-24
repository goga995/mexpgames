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

        var response = await query.Select(g => new GameResponse(
            g.Id,
            g.Name,
            g.CreatorName,
            g.ReleseDate,
            g.GameType,
            g.Rating,
            g.ImageLinks,
            g.Description
        )).ToListAsync();
        return response;
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        var result = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        return result;
    }

    public void Update(Game game)
    {
        _context.Games.Update(game);
    }
}
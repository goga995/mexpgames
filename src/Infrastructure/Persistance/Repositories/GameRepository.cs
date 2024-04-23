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
        throw new NotImplementedException();
    }

    public async Task<List<Game>> GetAllAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.Games.FindAsync(id);
    }

    public void Update(Game game)
    {
        throw new NotImplementedException();
    }
}
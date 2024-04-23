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
        throw new NotImplementedException();
    }

    public void Delete(Game game)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Game>> GetAllAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public Task<Game> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Game game)
    {
        throw new NotImplementedException();
    }
}
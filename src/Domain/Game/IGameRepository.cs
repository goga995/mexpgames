namespace Domain.Game;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(Guid id);
    Task<List<GameResponse>> GetAllAsync();
    void AddGame(Game game);
    void Update(Game game);
    void Delete(Game game);
}
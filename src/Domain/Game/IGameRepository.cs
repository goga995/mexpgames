namespace Domain.Game;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(int id);
    Task<List<Game>> GetAllAsync();
    void AddGame(Game game);
    void Update(Game game);
    void Delete(Game game);
}
using Domain.Game;
using HtmlAgilityPack;
using Infrastructure.Persistance.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistance.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;
    private static readonly HttpClient _httpClient = new();



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

    public async Task<Game?> Scrape(string SteamGameID)
    {
        var BaseAddress = new Uri("https://store.steampowered.com/app/");
        try
        {
            var htmlAdress = await _httpClient.GetStringAsync(BaseAddress + SteamGameID);
            var doc = new HtmlDocument();

            doc.LoadHtml(htmlAdress);

            var nameElement = doc.DocumentNode.SelectSingleNode("//*[@id=\"appHubAppName\"]");
            string name = nameElement.InnerText;
            if (name is null)
                throw new ArgumentNullException();

            var creatorNameElement = doc.DocumentNode.SelectSingleNode("//*[@id=\"developers_list\"]/a");
            var creatorName = creatorNameElement.InnerText;
            if (creatorName is null)
                throw new ArgumentNullException();




            var descriptionElements = doc.DocumentNode.SelectSingleNode("//*[@id=\"game_highlights\"]/div[1]/div/div[2]/text()");
            var description = descriptionElements.InnerText;
            var game = Game.Create(name, creatorName, DateTime.UtcNow, GameType.Action, 59, null, description);
            return game;

        }
        catch (System.Exception ex)
        {

            Console.WriteLine($"Error scraping rating: {ex.Message}");
            throw;
        }
    }
}
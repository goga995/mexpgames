using Domain.Shared;

namespace Domain.Game;

public sealed class Game : Entity
{
    private Game(
                 string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 IEnumerable<string>? imageLinks,
                 string description) : base(Guid.NewGuid())
    {
        Name = name;
        CreatorName = creatorName;
        ReleseDate = releseDate;
        GameType = gameType;
        Rating = rating;
        ImageLinks = imageLinks;
        Description = description;
    }

    public string Name { get; private set; } = string.Empty;
    public string CreatorName { get; private set; } = string.Empty;
    public DateTime ReleseDate { get; private set; }
    public GameType GameType { get; private set; }
    public int Rating { get; private set; }
    public IEnumerable<string>? ImageLinks { get; set; }
    public string Description { get; set; } = string.Empty;


    public static Game Create(
                             string name,
                             string creatorName,
                             DateTime releseDate,
                             GameType gameType,
                             int rating,
                             IEnumerable<string>? imageLinks,
                             string description)
    {
        var game = new Game(name, creatorName, releseDate, gameType, rating, imageLinks, description);
        //Here you can add domain event
        return game;
    }
}
namespace Domain.Game;

public record GameResponse(Guid id, string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 IEnumerable<string>? imageLinks,
                 string description);
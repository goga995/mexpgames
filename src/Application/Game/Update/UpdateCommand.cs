using Application.Abstractions.Messaging;
using Domain.Game;
using Domain.Shared;

namespace Application.Game.Update;

public sealed record UpdateCommand(Guid id, string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 List<string>? imageLinks,
                 string description) : ICommand;

public record UpdateGameRequest(string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 List<string>? imageLinks,
                 string description);
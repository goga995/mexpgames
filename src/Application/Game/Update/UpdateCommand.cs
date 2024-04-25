using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Update;

public sealed record UpdateCommand(Guid id, string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 List<string>? imageLinks,
                 string description) : IRequest<Result>;

public record UpdateGameRequest(string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 List<string>? imageLinks,
                 string description);
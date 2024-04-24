using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Update;

public sealed record UpdateCommand(Guid id, string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 IEnumerable<string>? imageLinks,
                 string description) : IRequest<Result>;

public record UpdateProductRequest(string name,
                 string creatorName,
                 DateTime releseDate,
                 GameType gameType,
                 int rating,
                 IEnumerable<string>? imageLinks,
                 string description);
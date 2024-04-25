using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Create;

public sealed record CreateCommand(string Name,
                                   string CreatorName,
                                   DateTime ReleaseDate,
                                   GameType GameType,
                                   int Rating,
                                   List<string>? ImageLinks,
                                   string Description) : IRequest<Result<Guid>>;

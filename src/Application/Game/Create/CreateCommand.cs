using Application.Abstractions.Messaging;
using Domain.Game;
using Domain.Shared;

namespace Application.Game.Create;

public sealed record CreateCommand(string Name,
                                   string CreatorName,
                                   DateTime ReleaseDate,
                                   GameType GameType,
                                   int Rating,
                                   List<string>? ImageLinks,
                                   string Description) : ICommand<Guid>;

using Application.Abstractions.Caching;
using Domain.Game;

namespace Application.Game.GetAll;

public sealed record GetAllQuery() : ICachedQuery<List<GameResponse>>
{
    public string Key => $"all-games-Default";

    public TimeSpan? Expiration => null;
}

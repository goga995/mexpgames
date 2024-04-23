using Domain.Shared;

namespace Domain.Game;

public static class GameError
{
    public static Error NotFound => new Error("Game.NotFound", "The Game With Provided Id was not found");

}
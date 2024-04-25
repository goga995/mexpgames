using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.SteamScrape;

public class SteamScrapeHandler : IRequestHandler<SteamScrapeCommand, Result<Domain.Game.Game>>
{
    private readonly IGameRepository _gameRepository;

    public SteamScrapeHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result<Domain.Game.Game>> Handle(SteamScrapeCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.Scrape(request.SteamId);
        if (game is null)
            return Result.Failure<Domain.Game.Game>(Error.NullValue);

        return Result.Success(game);
    }
}
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.GetById;

public class GeyByIdHandler : IRequestHandler<GetByIdQuery, Result<GameResponse>>
{
    private readonly IGameRepository _gameRepository;

    public GeyByIdHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result<GameResponse>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.id);

        if (game is null)
            return (Result<GameResponse>)Result.Failure(GameError.NotFound);

        return Result.Success(new GameResponse(game.Id,
                                               game.Name,
                                               game.CreatorName,
                                               game.ReleseDate,
                                               game.GameType,
                                               game.Rating,
                                               game.ImageLinks,
                                               game.Description));
    }
}
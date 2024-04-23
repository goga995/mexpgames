using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.GetAll;

public class GetAllHandler : IRequestHandler<GetAllQuery, Result<List<Domain.Game.Game>>>
{
    private readonly IGameRepository _gameRepository;

    public GetAllHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result<List<Domain.Game.Game>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var games = await _gameRepository.GetAllAsync();

        if (games is null)
            return Result.Failure<List<Domain.Game.Game>>(GameError.NotFound);

        return Result.Success(games);
    }
}
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.GetAll;

public class GetAllHandler : IRequestHandler<GetAllQuery, Result<List<GameResponse>>>
{
    private readonly IGameRepository _gameRepository;

    public GetAllHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result<List<GameResponse>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var games = await _gameRepository.GetAllAsync();

        return Result.Success(games);
    }
}
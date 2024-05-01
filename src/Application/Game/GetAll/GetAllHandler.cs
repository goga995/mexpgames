using Application.Abstractions.Messaging;
using Domain.Game;
using Domain.Shared;

namespace Application.Game.GetAll;

public class GetAllHandler : IQueryHandler<GetAllQuery, List<GameResponse>>
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
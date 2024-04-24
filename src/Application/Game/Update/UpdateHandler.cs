using System.Runtime.CompilerServices;
using Application.Data;
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Update;

public class UpdateHandler : IRequestHandler<UpdateCommand, Result>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.id);

        if (game is null)
        {
            return Result.Failure(GameError.NotFound);
        }

        _gameRepository.Update(game);
        return Result.Success();
    }
}
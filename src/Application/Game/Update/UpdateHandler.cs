using Application.Abstractions.Messaging;
using Application.Data;
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Update;

public class UpdateHandler : ICommandHanlder<UpdateCommand>
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

        game.Update(request.name,
                    request.creatorName,
                    request.releseDate,
                    request.gameType,
                    request.rating,
                    request.imageLinks,
                    request.description);

        _gameRepository.Update(game);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
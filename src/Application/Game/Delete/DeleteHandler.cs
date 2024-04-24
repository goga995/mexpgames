using Application.Data;
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Delete;

public class DeleteHandler : IRequestHandler<DeleteCommand, Result<Guid>>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.id);

        if (game is null)
        {
            return (Result<Guid>)Result.Failure(Error.NullValue);
        }
        _gameRepository.Delete(game);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(game.Id);
    }
}
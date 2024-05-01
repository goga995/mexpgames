using Application.Abstractions.Messaging;
using Application.Data;
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Create;

internal sealed class CreateHandler : ICommandHanlder<CreateCommand, Guid>
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var game = Domain.Game.Game.Create(
            request.Name,
            request.CreatorName,
            request.ReleaseDate,
            request.GameType,
            request.Rating,
            request.ImageLinks,
            request.Description
        );
        _gameRepository.AddGame(game);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(game.Id);
    }
}
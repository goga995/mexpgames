using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.Create;
//Nemam bus jos implementiran
internal sealed class GameCreatedDomainEventHandler : INotificationHandler<GameCreatedDomainEvent>
{
    private readonly IGameRepository _gameRepository;
    private readonly IEmailService _emailService;

    public GameCreatedDomainEventHandler(IGameRepository gameRepository, IEmailService emailService)
    {
        _gameRepository = gameRepository;
        _emailService = emailService;
    }



    public async Task Handle(GameCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        //Ovde bi trebao member da bude

        System.Console.WriteLine("test");

    }
}
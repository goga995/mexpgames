using Domain.Shared;

namespace Domain.Game;

public sealed record GameCreatedDomainEvent(Guid Id, Guid GameId) : IDomainEvent;

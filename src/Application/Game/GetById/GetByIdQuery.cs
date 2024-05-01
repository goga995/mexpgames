using Application.Abstractions.Messaging;
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.GetById;

public sealed record GetByIdQuery(Guid id) : IQuery<GameResponse>;

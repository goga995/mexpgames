using Application.Abstractions.Messaging;
using Domain.Shared;
using MediatR;

namespace Application.Game.Delete;

public sealed record DeleteCommand(Guid id) : ICommand<Guid>;


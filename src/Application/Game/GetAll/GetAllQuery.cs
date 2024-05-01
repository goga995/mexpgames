using Application.Abstractions.Messaging;
using Domain.Game;
using Domain.Shared;
using MediatR;

namespace Application.Game.GetAll;

public sealed record GetAllQuery() : IQuery<List<GameResponse>>;

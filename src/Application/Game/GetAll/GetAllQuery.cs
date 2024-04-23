using Domain.Shared;
using MediatR;

namespace Application.Game.GetAll;

public sealed record GetAllQuery() : IRequest<Result<List<Domain.Game.Game>>>;

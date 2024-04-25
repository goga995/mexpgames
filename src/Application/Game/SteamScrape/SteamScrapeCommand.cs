using Domain.Shared;
using MediatR;

namespace Application.Game.SteamScrape;

public sealed record SteamScrapeCommand(string SteamId) : IRequest<Result<Domain.Game.Game>>;

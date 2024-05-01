using Application.Abstractions.Messaging;
using Domain.Shared;
using MediatR;

namespace Application.Game.SteamScrape;

public sealed record SteamScrapeCommand(string SteamId) : ICommand<Domain.Game.Game>;

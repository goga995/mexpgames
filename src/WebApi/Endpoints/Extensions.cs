using Application.Game.Create;
using Application.Game.Delete;
using Application.Game.GetAll;
using Application.Game.GetById;
using Application.Game.SteamScrape;
using Application.Game.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

public static class Extensions
{
    public static void AddEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/games", async (ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetAllQuery()));
            }
            catch (Exception e)
            {

                return Results.NotFound(e.Message);
            }
        });

        builder.MapPost("/games", async (CreateCommand command, ISender sender) =>
        {
            var send = await sender.Send(command);

            return Results.Ok(send);
        });

        builder.MapGet("/game/{id:Guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetByIdQuery(id)));
            }
            catch (System.Exception e)
            {

                return Results.NotFound(e.Message);
            }
        });

        builder.MapDelete("/games/{id:Guid}", async (Guid id, ISender sender) =>
        {

            try
            {
                return Results.Ok(await sender.Send(new DeleteCommand(id)));
            }
            catch (System.Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        builder.MapPut("/games/{id:guid}", async (Guid id, [FromBody] UpdateGameRequest request, ISender sender) =>
        {
            var command = new UpdateCommand(
                id,
                request.name,
                request.creatorName,
                request.releseDate,
                request.gameType,
                request.rating,
                request.imageLinks,
                request.description
            );
            await sender.Send(command);
            return Results.NoContent();
        });

        builder.MapPost("/games/Scrape/", async (string SteamId, ISender sender) =>
        {
            if (string.IsNullOrEmpty(SteamId))
            {
                return Results.BadRequest("Steam Id cant be null");
            }
            var result = await sender.Send(new SteamScrapeCommand(SteamId));

            return Results.Ok(result);
        });

    }
}
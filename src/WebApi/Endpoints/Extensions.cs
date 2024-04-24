using Application.Game.Create;
using Application.Game.GetAll;
using Application.Game.GetById;
using MediatR;

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

        builder.MapGet("/game/{Guid:id}", async (Guid id, ISender sender) =>
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

    }
}
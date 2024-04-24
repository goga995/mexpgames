using Application.Game.Create;
using Application.Game.GetAll;
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

                return Results.NotFound(e);
            }
        });

        builder.MapPost("/games", async (CreateCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });


    }
}
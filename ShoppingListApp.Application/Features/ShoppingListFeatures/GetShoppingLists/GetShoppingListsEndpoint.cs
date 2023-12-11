using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;
public class GetShoppingListsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists", GetShoppingLists)
        .WithName("GetShoppingLists")
        .RequireAuthorization();
    }

    private async Task<IResult> GetShoppingLists(string userName, IMediator mediator)
    {
        var shoppingLists = await mediator.Send(new GetShoppingListsRequest(userName));
        if (shoppingLists == null)
        {
           return TypedResults.Ok(Array.Empty<ShoppingList>());
        }
        return TypedResults.Ok(shoppingLists);
    }
}

using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Common.DTO;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;
public class AddItemToShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/shoppinglists/{shoppingListID:int}/items", AddItemToShoppingList)
        .WithName("AddItemToShoppingList")
        .RequireAuthorization();
    }

    public async Task<IResult> AddItemToShoppingList(int shoppingListID, string userName, ShoppingItemDTO shoppingItemDTO, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new AddItemToShoppingListRequest(shoppingListID, userName, shoppingItemDTO));
        return TypedResults.Ok(shoppingList);
    }
}

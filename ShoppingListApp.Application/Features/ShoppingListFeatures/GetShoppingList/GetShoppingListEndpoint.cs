using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Common.Responses;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;
public class GetShoppingListEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists/{shoppingListID:int}", GetShoppingList)
        .WithName("GetShoppingList")
        .RequireAuthorization();
    }

    private async Task<IResult> GetShoppingList(int shoppingListID,string userName, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new GetShoppingListRequest(shoppingListID, userName));
        if (shoppingList == null)
        {
            return TypedResults.Ok(new MessageResponse { Message = $"Shopping list with id: {shoppingListID} not found" });
        }
        return TypedResults.Ok(shoppingList);
    }
}

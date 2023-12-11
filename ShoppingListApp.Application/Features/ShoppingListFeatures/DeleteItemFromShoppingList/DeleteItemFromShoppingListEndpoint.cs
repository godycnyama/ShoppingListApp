using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteItemFromShoppingList;
public class DeleteItemFromShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/v1/shoppinglists/{shoppingListID:int}/items", DeleteItemFromShoppingList)
        .WithName("DeleteItemFromShoppingList")
        .RequireAuthorization();
    }

    private async Task<IResult> DeleteItemFromShoppingList(int shoppingListID,string userName, int itemID, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new DeleteItemFromShoppingListRequest(shoppingListID,userName, itemID));
        return TypedResults.Ok(shoppingList);
    }
}

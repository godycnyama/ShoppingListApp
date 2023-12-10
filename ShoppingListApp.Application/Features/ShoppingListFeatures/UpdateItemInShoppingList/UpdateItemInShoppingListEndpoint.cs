using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Common.DTO;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingList;
public class UpdateItemInShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/shoppinglists/{shoppingListID:int}/items", UpdateItemInShoppingList)
        .WithName("UpdateItemInShoppingList");
    }

    private async Task<IResult> UpdateItemInShoppingList(int shoppingListID, int shoppingItemID, string userName, ShoppingItemDTO shoppingItem, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new UpdateItemInShoppingListRequest(shoppingListID, shoppingItemID, userName, shoppingItem));
        return TypedResults.Ok(shoppingList);
    }
}

using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;
public class DeleteShoppingListEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/v1/shoppinglists/{shoppingListID:int}", DeleteShoppingList)
        .WithName("DeleteShoppingList")
        .RequireAuthorization();
    }

    private async Task<IResult> DeleteShoppingList(int shoppingListID,string userName, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new DeleteShoppingListRequest(shoppingListID, userName));
        return Results.Ok(shoppingList);
    }
}

using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateShoppingList;
public class UpdateShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/shoppinglists", UpdateShoppingList)
        .WithName("UpdateShoppingList")
        .RequireAuthorization();
    }

    private async Task<IResult> UpdateShoppingList(UpdateShoppingListRequest updateShoppingListRequest, IMediator mediator)
    {
        var shoppingList = await mediator.Send(updateShoppingListRequest);
        return TypedResults.Ok(shoppingList);
    }
}

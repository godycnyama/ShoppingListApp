using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
public class CreateShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/shoppinglists", CreateShoppingList)
        .WithName("CreateShoppingList")
        .RequireAuthorization();
    }

    private async Task<IResult> CreateShoppingList(CreateShoppingListRequest createShoppingListRequest, IMediator mediator)
    {
        var shoppingList = await mediator.Send(createShoppingListRequest);
        return TypedResults.Ok(shoppingList);
    }
}

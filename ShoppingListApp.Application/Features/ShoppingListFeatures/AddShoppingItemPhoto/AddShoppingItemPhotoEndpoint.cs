using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddShoppingItemPhoto;
public class AddShoppingItemPhotoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/shoppinglists/{shoppingListID:int}/items/{itemID:int}/photo", AddItemPhoto)
        .WithName("AddItemPhoto")
        .RequireAuthorization(); 
    }

    private async Task<IResult> AddItemPhoto(int shoppingListID, string userName, int itemID, IFormFile file, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new AddShoppingItemPhotoRequest(shoppingListID, userName, itemID, file));
        return TypedResults.Ok(shoppingList);
    }
}

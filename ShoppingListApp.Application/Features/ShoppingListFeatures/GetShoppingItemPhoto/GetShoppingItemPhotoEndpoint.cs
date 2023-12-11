using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Common.Responses;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingItemPhoto;
public class GetShoppingItemPhotoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists/{shoppingListID:int}/items/{itemID:int}/photo/{fileName}", GetShoppingItemPhoto)
        .WithName("GetShoppingItemPhoto");
    }

    private async Task<IResult> GetShoppingItemPhoto(int shoppingListID, string UserName, int itemID, string fileName,IMediator mediator)
    {
        FileResponse fileResponse = await mediator.Send(new GetShoppingItemPhotoRequest(fileName));
        return TypedResults.File(fileResponse.Data, fileResponse.ContentType, fileResponse.FileName);
    }
}

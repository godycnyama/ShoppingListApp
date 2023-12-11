using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingItemPhoto;
public class GetShoppingItemPhotoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists/{shoppingListID:int}/items/{itemID:int}/photo/{fileName}", GetShoppingItemPhoto)
        .WithName("GetShoppingItemPhoto")
        .RequireAuthorization();
    }

    private async Task<IResult> GetShoppingItemPhoto(int shoppingListID, string UserName, int itemID, string fileName,IMediator mediator)
    {
        FileResponse fileResponse = await mediator.Send(new GetShoppingItemPhotoRequest(fileName));
        return TypedResults.File(fileResponse.Data, fileResponse.ContentType, fileResponse.FileName);
    }
}

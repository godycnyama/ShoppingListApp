using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemPhoto;
public class AddItemPhotoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/shoppinglists/{shoppingListID:int}/items/{itemID:int}/photo", AddItemPhoto)
        .WithName("AddItemPhoto");
    }

    private async Task<IResult> AddItemPhoto(int shoppingListID, int userID, int itemID, ISender sender)
    {
        var shoppingList = await sender.Send(new AddItemPhotoRequest(id, 3));
        return Results.Ok(shoppingList);
    }
}

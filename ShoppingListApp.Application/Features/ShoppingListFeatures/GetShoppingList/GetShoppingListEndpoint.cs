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

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingListQuery;
public class GetShoppingListEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists/{id:int}", GetShoppingListByID)
        .WithName("GetShoppingList");
    }

    private async Task<IResult> GetShoppingListByID(int id, ISender sender)
    {
        var shoppingList = await sender.Send(new GetShoppingListRequest(id, 3));
        return Results.Ok(shoppingList);
    }
}

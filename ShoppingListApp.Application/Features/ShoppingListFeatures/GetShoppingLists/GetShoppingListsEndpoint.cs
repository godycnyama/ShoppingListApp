using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingListQuery;
using ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingListsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;
public class GetShoppingListsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists", GetShoppingLists)
        .WithName("GetShoppingLists");
    }

    private async Task<IResult> GetShoppingLists(ISender sender)
    {
        var shoppingLists = await sender.Send(new GetShoppingListsRequest(2, 3));
        return Results.Ok(shoppingLists);
    }
}

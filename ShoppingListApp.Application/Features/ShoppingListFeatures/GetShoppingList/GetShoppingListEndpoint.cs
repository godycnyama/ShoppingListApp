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

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;
public class GetShoppingListEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/shoppinglists/{shoppingListID:int}", GetShoppingList)
        .WithName("GetShoppingList");
    }

    private async Task<IResult> GetShoppingList(int shoppingListID,string userName, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new GetShoppingListRequest(shoppingListID, userName));
        return TypedResults.Ok(shoppingList);
    }
}

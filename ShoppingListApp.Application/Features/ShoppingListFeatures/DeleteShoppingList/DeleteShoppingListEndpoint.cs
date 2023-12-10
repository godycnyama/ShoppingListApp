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

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;
public class DeleteShoppingListEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/v1/shoppinglists/{shoppingListID:int}", DeleteShoppingList)
        .WithName("DeleteShoppingList");
    }

    private async Task<IResult> DeleteShoppingList(int shoppingListID,string userName, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new DeleteShoppingListRequest(shoppingListID, userName));
        return Results.Ok(shoppingList);
    }
}

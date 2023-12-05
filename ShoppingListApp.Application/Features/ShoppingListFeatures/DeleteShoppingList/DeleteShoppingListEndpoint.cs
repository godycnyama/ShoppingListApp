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
        app.MapDelete("api/v1/shoppinglists/{id:int}", DeleteShoppingList)
        .WithName("DeleteShoppingList");
    }

    private async Task<IResult> DeleteShoppingList(int id, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new DeleteShoppingListRequest(id, 3));
        return Results.Ok(shoppingList);
    }
}

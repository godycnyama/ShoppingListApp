using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;
public class AddItemToShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/shoppinglists/{shoppingListID:int}/items", AddItemToShoppingList)
        .WithName("AddItemToShoppingList");
    }

    private async Task<IResult> AddItemToShoppingList(int shoppingListID, int userID, ShoppingItemDTO shoppingItemDTO, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new AddItemToShoppingListRequest(shoppingListID, userID, shoppingItemDTO));
        return TypedResults.Ok(shoppingList);
    }
}

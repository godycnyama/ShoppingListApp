using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingListCommand;
using ShoppingListApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingList;
public class UpdateItemInShoppingListEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/shoppinglists/{shoppingListID:int}/items", UpdateItemInShoppingList)
        .WithName("UpdateItemInShoppingList");
    }

    private async Task<IResult> UpdateItemInShoppingList(int shoppingListID, int userID, ShoppingItem shoppingItem, IMediator mediator)
    {
        var shoppingList = await mediator.Send(new UpdateItemInShoppingListRequest(shoppingListID, userID, shoppingItem));
        return Results.Ok(shoppingList);
    }
}

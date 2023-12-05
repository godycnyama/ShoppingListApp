using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
using ShoppingListApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingListQuery;
public class CreateShoppingListEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/shoppinglists", CreateShoppingList)
        .WithName("CreateShoppingList");
    }

    private async Task<IResult> CreateShoppingList(CreateShoppingListRequest createShoppingListRequest, IMediator mediator)
    {
        var shoppingList = await mediator.Send(createShoppingListRequest);
        return TypedResults.Ok(shoppingList);
    }
}

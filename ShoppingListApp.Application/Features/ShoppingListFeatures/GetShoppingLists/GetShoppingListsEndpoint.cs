using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;
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

    private async Task<IResult> GetShoppingLists(string userName, IMediator mediator)
    {
        var shoppingLists = await mediator.Send(new GetShoppingListsRequest(userName));
        return TypedResults.Ok(shoppingLists);
    }
}

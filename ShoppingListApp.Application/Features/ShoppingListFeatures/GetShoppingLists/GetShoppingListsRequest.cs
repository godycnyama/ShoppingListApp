using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;

public sealed record GetShoppingListsRequest(string UserName) : IRequest<IEnumerable<ShoppingList>>;

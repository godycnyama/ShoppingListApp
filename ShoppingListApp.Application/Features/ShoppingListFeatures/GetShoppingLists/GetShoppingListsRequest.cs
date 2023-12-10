using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;

public sealed record GetShoppingListsRequest(int ShoppingListID, int UserName) : IRequest<IEnumerable<ShoppingList>>;

using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;

public sealed record GetShoppingListsRequest(int ShoppingListID, int UserID) : IRequest<IEnumerable<ShoppingList>>;

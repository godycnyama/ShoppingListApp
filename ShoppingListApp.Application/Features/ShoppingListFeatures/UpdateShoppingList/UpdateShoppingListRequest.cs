using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateShoppingList;

public sealed record UpdateShoppingListRequest(int ShoppingListID, int UserID, string Month, string Year, List<ShoppingItem> ShoppingItems) : IRequest<ShoppingList>;

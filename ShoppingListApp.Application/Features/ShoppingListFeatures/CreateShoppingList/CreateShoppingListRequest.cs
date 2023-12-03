using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;

public sealed record UpdateShoppingListRequest(int UserID, string Month, string Year, List<ShoppingItem> ShoppingItems) : IRequest<ShoppingList>;

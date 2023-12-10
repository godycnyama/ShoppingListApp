using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;

public sealed record CreateShoppingListRequest(int UserName, string Month, string Year, List<ShoppingItem> ShoppingItems) : IRequest<ShoppingList>;

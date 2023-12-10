using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;

public sealed record GetShoppingListRequest(int ShoppingListID, string UserName) : IRequest<ShoppingList>;

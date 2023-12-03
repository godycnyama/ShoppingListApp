using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;

public sealed record GetShoppingListRequest(int ShoppingListID, int UserID) : IRequest<ShoppingList>;

using MediatR;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteItemFromShoppingList;

public sealed record DeleteItemFromShoppingListRequest(int ShoppingListID, string UserName, int ItemID) : IRequest<ShoppingList>;

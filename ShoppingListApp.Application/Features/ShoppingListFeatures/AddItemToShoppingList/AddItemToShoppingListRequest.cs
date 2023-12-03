using MediatR;
using ShoppingListApp.Application.Common.DTO;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;

public sealed record AddItemToShoppingListRequest(int ShoppingListID,int UserID, ShoppingItemDTO ShoppingItemDTO) : IRequest<ShoppingList>;

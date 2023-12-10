using MediatR;
using ShoppingListApp.Application.Common.DTO;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;

public sealed record AddItemToShoppingListRequest(int ShoppingListID,string UserName, ShoppingItemDTO ShoppingItemDTO) : IRequest<ShoppingList>;

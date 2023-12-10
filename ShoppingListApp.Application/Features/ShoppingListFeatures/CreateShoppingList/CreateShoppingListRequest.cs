using MediatR;
using ShoppingListApp.Application.Common.DTO;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;

public sealed record CreateShoppingListRequest(string UserName, string Month, string Year, List<ShoppingItemDTO> ShoppingItems) : IRequest<ShoppingList>;

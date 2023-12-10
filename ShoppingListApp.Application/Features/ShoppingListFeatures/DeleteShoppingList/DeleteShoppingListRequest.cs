using MediatR;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;

public sealed record DeleteShoppingListRequest(int ShoppingListID, string UserName) : IRequest<MessageResponse>;

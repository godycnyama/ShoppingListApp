using MediatR;
using ShoppingListApp.Application.Common.Responses;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;

public sealed record DeleteShoppingListRequest(int ShoppingListID, string UserName) : IRequest<MessageResponse>;

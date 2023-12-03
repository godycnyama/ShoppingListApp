using MediatR;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;

public sealed record DeleteShoppingListRequest(int ShoppingListID, int UserID) : IRequest<MessageResponse>;

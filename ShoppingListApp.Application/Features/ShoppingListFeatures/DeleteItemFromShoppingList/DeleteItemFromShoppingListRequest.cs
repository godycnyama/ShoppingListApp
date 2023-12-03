using MediatR;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteItemFromShoppingList;

public sealed record DeleteItemFromShoppingListRequest(int ShoppingListID, int UserID, int ItemID) : IRequest<MessageResponse>;

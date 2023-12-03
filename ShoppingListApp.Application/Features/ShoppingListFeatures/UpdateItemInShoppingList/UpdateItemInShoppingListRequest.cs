using MediatR;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingList;

public sealed record UpdateItemInShoppingListRequest(int ShoppingListID, int UserID, ShoppingItem ShoppingItem) : IRequest<ShoppingList>;

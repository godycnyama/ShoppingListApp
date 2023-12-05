using MediatR;
using Microsoft.AspNetCore.Http;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddShoppingItemPhoto;

public sealed record AddShoppingItemPhotoRequest(int ShoppingListID, int UserID, int ItemID, IFormFile File) : IRequest<ShoppingList>;

using MediatR;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingItemPhoto;

public sealed record GetShoppingItemPhotoRequest(string FileName) : IRequest<FileResponse>;

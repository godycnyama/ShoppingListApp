using MediatR;
using Microsoft.AspNetCore.Http;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemPhoto;

public sealed record AddItemPhotoRequest(int ShoppingListID, int UserID, int ItemID) : IRequest<MessageResponse>;

﻿using MediatR;
using Microsoft.AspNetCore.Http;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddShoppingItemPhoto;

public sealed record AddShoppingItemPhotoRequest(int ShoppingListID, string UserName, int ItemID, IFormFile File) : IRequest<ShoppingList>;

﻿using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;
public sealed class DeleteShoppingListHandler : IRequestHandler<DeleteShoppingListRequest, MessageResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DeleteShoppingListHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }

    public async Task<MessageResponse> Handle(DeleteShoppingListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            ShoppingList shoppingList = await unitOfWork.ShoppingListRepository.GetAsync(item => item.ShoppingListID == request.ShoppingListID && item.UserName.Equals(request.UserName));
            if (shoppingList is null)
            {
                throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
            }
            unitOfWork.ShoppingListRepository.Remove(shoppingList);
            await unitOfWork.CommitAsync();
            return new MessageResponse { Message = $"Shopping list with id: {request.ShoppingListID} deleted successfully" };
        }
        catch (Exception)
        {

            throw;
        }
    }
}

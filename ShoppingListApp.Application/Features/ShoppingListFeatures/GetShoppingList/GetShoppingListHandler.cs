using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;
public sealed class GetShoppingListHandler : IRequestHandler<GetShoppingListRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;

    public GetShoppingListHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<ShoppingList> Handle(GetShoppingListRequest request, CancellationToken cancellationToken)
    {
        ShoppingList shoppingList = await unitOfWork.ShoppingListRepository.GetAsync(item => item.ShoppingListID == request.ShoppingListID && item.UserID == request.UserID);
        if (shoppingList is null)
        {
            throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
        }
        return shoppingList;
    }
}

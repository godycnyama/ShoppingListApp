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
        ShoppingList shoppingList = unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserName.Equals(request.UserName) && o.ShoppingListID == request.ShoppingListID).FirstOrDefault();

        if (shoppingList is null)
        {
            throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
        }
        return shoppingList;
    }
}

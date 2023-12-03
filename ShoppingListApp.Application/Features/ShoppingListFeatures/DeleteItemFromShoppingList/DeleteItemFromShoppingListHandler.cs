using AutoMapper;
using MediatR;
using ShoppingItemApp.Application.Exceptions;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteItemFromShoppingList;
public sealed class DeleteItemFromShoppingListHandler : IRequestHandler<DeleteItemFromShoppingListRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DeleteItemFromShoppingListHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }

    public async Task<ShoppingList> Handle(DeleteItemFromShoppingListRequest request, CancellationToken cancellationToken)
    {
        ShoppingList shoppingList = unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserID == request.UserID && o.ShoppingListID == request.ShoppingListID).FirstOrDefault();
        if (shoppingList is null)
        {
            throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
        }
        ShoppingItem shoppingItem = shoppingList.ShoppingItems.FirstOrDefault(o => o.ShoppingItemID == request.ItemID);
        if (shoppingItem is null)
        {
            throw new ShoppingItemNotFoundException(request.ItemID.ToString());
        }
        mapper.Map(request.ShoppingItem, shoppingItem);
        shoppingList.ShoppingItems.FirstOrDefault(o => o.ShoppingItemID == request.ItemID).Quantity = shoppingItem.Quantity;
        unitOfWork.ShoppingListRepository.Update(shoppingList);
        await unitOfWork.CommitAsync();
        return shoppingList;
    }
}

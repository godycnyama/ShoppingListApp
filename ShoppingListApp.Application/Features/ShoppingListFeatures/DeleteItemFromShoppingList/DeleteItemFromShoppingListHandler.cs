using AutoMapper;
using MediatR;
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
        try
        {
            ShoppingList shoppingList = unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserName.Equals(request.UserName) && o.ShoppingListID == request.ShoppingListID).FirstOrDefault();
            if (shoppingList is null)
            {
                throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
            }
            ShoppingItem shoppingItem = shoppingList.ShoppingItems.FirstOrDefault(o => o.ShoppingItemID == request.ItemID);
            if (shoppingItem is null)
            {
                throw new ShoppingItemNotFoundException(request.ItemID.ToString());
            }

            shoppingList.ShoppingItems.Remove(shoppingItem);
            unitOfWork.ShoppingListRepository.Update(shoppingList);
            await unitOfWork.CommitAsync();
            return shoppingList;
        }
        catch (Exception)
        {

            throw;
        }
    }
}

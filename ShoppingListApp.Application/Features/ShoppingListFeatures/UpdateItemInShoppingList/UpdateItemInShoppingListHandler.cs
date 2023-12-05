using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingList;
public sealed class UpdateItemInShoppingListHandler : IRequestHandler<UpdateItemInShoppingListRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateItemInShoppingListHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }

    public async Task<ShoppingList> Handle(UpdateItemInShoppingListRequest request, CancellationToken cancellationToken)
    {
        ShoppingList shoppingList = unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserID == request.UserID && o.ShoppingListID == request.ShoppingListID).FirstOrDefault();
        if (shoppingList is null)
        {
            throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
        }
        ShoppingItem shoppingItem = shoppingList.ShoppingItems.FirstOrDefault(o => o.ShoppingItemID == request.ShoppingItem.ShoppingItemID);
        if (shoppingItem is null)
        {
            throw new ShoppingItemNotFoundException(request.ShoppingItem.ShoppingItemID.ToString());
        }
        mapper.Map(request.ShoppingItem, shoppingItem);

        unitOfWork.ShoppingListRepository.Update(shoppingList);
        await unitOfWork.CommitAsync();
        return shoppingList;
    }
}

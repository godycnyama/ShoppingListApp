using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;
public sealed class AddItemToShoppingListHandler : IRequestHandler<AddItemToShoppingListRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AddItemToShoppingListHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }

    public async Task<ShoppingList> Handle(AddItemToShoppingListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            ShoppingList shoppingList = unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserName.Equals(request.UserName) && o.ShoppingListID == request.ShoppingListID).FirstOrDefault();
            if (shoppingList is null)
            {
                throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
            }
            ShoppingItem shoppingItem = new();
            mapper.Map(request.ShoppingItemDTO, shoppingItem);
            shoppingList.ShoppingItems.Add(shoppingItem);
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

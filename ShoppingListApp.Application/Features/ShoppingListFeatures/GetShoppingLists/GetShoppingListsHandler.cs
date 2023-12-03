using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;
public sealed class GetShoppingListsHandler : IRequestHandler<GetShoppingListsRequest, IEnumerable<ShoppingList>>
{
    private readonly IUnitOfWork unitOfWork;

    public GetShoppingListsHandler(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<ShoppingList>> Handle(GetShoppingListsRequest request, CancellationToken cancellationToken)
    {
        var shoppingLists = await unitOfWork.ShoppingListRepository.GetAllAsync(item => item.ShoppingListID == request.ShoppingListID && item.UserID == request.UserID);
        if (shoppingLists is null)
        {
            throw new ShoppingListsNotFoundException();
        }
        return shoppingLists;
    }
}

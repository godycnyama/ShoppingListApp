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
        var shoppingLists = unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserName.Equals(request.UserName)).ToList();
        if (shoppingLists.Count() == 0)
        {
            throw new ShoppingListsNotFoundException();
        }
        return shoppingLists;
    }
}

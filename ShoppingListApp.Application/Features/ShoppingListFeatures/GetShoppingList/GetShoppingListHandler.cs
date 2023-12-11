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
        try
        {
            return unitOfWork.ShoppingListRepository.Get(o => o.ShoppingItems).Where(o => o.UserName.Equals(request.UserName) && o.ShoppingListID == request.ShoppingListID).FirstOrDefault();

        }
        catch (Exception)
        {

            throw;
        }
    }
}

using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateShoppingList;
public sealed class UpdateShoppinListHandler : IRequestHandler<UpdateShoppingListRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateShoppinListHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }

    public async Task<ShoppingList> Handle(UpdateShoppingListRequest request, CancellationToken cancellationToken)
    {
        ShoppingList shoppingList = await unitOfWork.ShoppingListRepository.GetAsync(item => item.ShoppingListID == request.ShoppingListID);
        if (shoppingList is null)
        {
            throw new ShoppingListNotFoundException(request.ShoppingListID.ToString());
        }
        mapper.Map(request, shoppingList);
        unitOfWork.ShoppingListRepository.Update(shoppingList);
        await unitOfWork.CommitAsync();
        return shoppingList;
    }
}

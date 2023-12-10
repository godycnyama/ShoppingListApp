using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
public sealed class CreateShoppingListHandler : IRequestHandler<CreateShoppingListRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateShoppingListHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
    }

    public async Task<ShoppingList> Handle(CreateShoppingListRequest request, CancellationToken cancellationToken)
    {
        ShoppingList shoppingList = mapper.Map<ShoppingList>(request);
        await unitOfWork.ShoppingListRepository.AddAsync(shoppingList);
        await unitOfWork.CommitAsync();
        return shoppingList;
    }
}

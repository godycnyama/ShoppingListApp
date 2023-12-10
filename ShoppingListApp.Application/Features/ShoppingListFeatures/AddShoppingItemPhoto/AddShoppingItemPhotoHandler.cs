using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddShoppingItemPhoto;
public sealed class AddShoppingItemPhotoHandler : IRequestHandler<AddShoppingItemPhotoRequest, ShoppingList>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private IFileService fileService;

    public AddShoppingItemPhotoHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IFileService _fileService)
    {
        unitOfWork = _unitOfWork;
        mapper = _mapper;
        fileService = _fileService;
    }

    public async Task<ShoppingList> Handle(AddShoppingItemPhotoRequest request, CancellationToken cancellationToken)
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

        var fileName = await fileService.UploadFile(request.File);
        shoppingItem.PhotoFileName = fileName;

        unitOfWork.ShoppingListRepository.Update(shoppingList);
        await unitOfWork.CommitAsync();
        return shoppingList;
    }
}

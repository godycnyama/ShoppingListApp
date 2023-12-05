using AutoMapper;
using MediatR;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingItemPhoto;
public sealed class GetShoppingItemPhotoHandler : IRequestHandler<GetShoppingItemPhotoRequest, FileResponse>
{
    IFileService _fileService;

    public GetShoppingItemPhotoHandler(IFileService fileService)
    {
        this._fileService = fileService;
    }

    public async Task<FileResponse> Handle(GetShoppingItemPhotoRequest request, CancellationToken cancellationToken)
    {
        return await _fileService.GetFile(request.FileName);
    }
}

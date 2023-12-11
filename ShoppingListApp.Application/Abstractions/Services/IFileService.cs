using Microsoft.AspNetCore.Http;
using ShoppingListApp.Application.Common.Responses;

namespace ShoppingListApp.Application.Abstractions.Services;
public interface IFileService
{
    Task<string> UploadFile(IFormFile file);
    Task<FileResponse> GetFile(string key);
}

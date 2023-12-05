using Microsoft.AspNetCore.Http;
using ShoppingListApp.Application.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Abstractions.Services;
public interface IFileService
{
    Task<string> UploadFile(IFormFile file);
    Task<FileResponse> GetFile(string key);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.Exceptions;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Infrastructure.Common.Configurations;
using static System.Net.Mime.MediaTypeNames;

namespace ShoppingListApp.Infrastructure.Services;
public class FileService : IFileService
{
    private ILogger<FileService> _logger { get; set; }
    private readonly IMinioClient _minioClient;
    private readonly IConfiguration _configuration;

    public FileService(IConfiguration configuration, ILogger<FileService> logger, IMinioClient minioClient)
    {
        this._logger = logger;
        this._minioClient = minioClient;
        this._configuration = configuration;
    }
    public async Task<string> UploadFile(IFormFile file)
    {
        try
        {
            var beArgs = new BucketExistsArgs()
                .WithBucket(_configuration["Minio:BacketName"]);
            bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(_configuration["Minio:BacketName"]);
                await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }

            // Upload a file to bucket.
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(_configuration["Minio:BacketName"])
                .WithObject(file.FileName)
                .WithStreamData(file.OpenReadStream())
                .WithObjectSize(file.OpenReadStream().Length)
                .WithContentType("application/octet-stream");
            await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
            return file.FileName;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FileResponse> GetFile(string fileName)
    {
        try
        {
            MemoryStream destinationStream = new();

            // Check if file exists
            var objstatreply = await _minioClient.StatObjectAsync(new StatObjectArgs()
            .WithBucket(_configuration["Minio:BacketName"])
            .WithObject(fileName)
            );
            if (objstatreply == null || objstatreply.DeleteMarker)
                throw new Exception("object not found or Deleted");

            // Get file
            var args = new GetObjectArgs()
                .WithBucket(_configuration["Minio:BacketName"])
                .WithObject(fileName)
                .WithCallbackStream((stream) =>
                {
                    stream.CopyTo(destinationStream);
                });
            var stat = await _minioClient.GetObjectAsync(args).ConfigureAwait(false);
            return new FileResponse
            {
                ContentType = stat.ContentType,
                Data = destinationStream.ToArray(),
                FileName = stat.ObjectName
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Infrastructure.Persistence.Context;
using ShoppingListApp.Infrastructure.Persistence.Repositories;
using ShoppingListApp.Infrastructure.Persistence.UnitOfWork;
using ShoppingListApp.Infrastructure.Services;

namespace ShoppingListApp.Infrastructure;
public static class ServiceExtensions
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLServer");
        services.AddDbContext<ShoppingListAppDataContext>(opt => opt.UseSqlServer(connectionString));
        services.AddMinio(configureClient => configureClient
            .WithEndpoint(Environment.GetEnvironmentVariable("MINIO_ENDPOINT") ?? configuration["Minio:Endpoint"])
            .WithCredentials(Environment.GetEnvironmentVariable("MINIO_ROOT_USER") ?? configuration["Minio:AccessKey"], Environment.GetEnvironmentVariable("MINIO_ROOT_PASSWORD") ?? configuration["Minio:SecretKey"])
            .WithSSL(false));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IFileService, FileService>();
    }

}

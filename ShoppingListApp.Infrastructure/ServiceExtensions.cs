using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Infrastructure.Persistence.Context;
using ShoppingListApp.Infrastructure.Persistence.Repositories;
using ShoppingListApp.Infrastructure.Persistence.UnitOfWork;

namespace ShoppingListApp.Infrastructure;
public static class ServiceExtensions
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLServer");
        services.AddDbContext<ShoppingListAppDataContext>(opt => opt.UseSqlServer(connectionString));
        services.AddMinio(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"]);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
    }

}

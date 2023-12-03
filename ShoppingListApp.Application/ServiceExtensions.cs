using FluentValidation;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShoppingListApp.Application.Common.Behaviors;
using System.Reflection;

namespace ShoppingListApp.Application;
public static class ServiceExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());     
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
    }

}

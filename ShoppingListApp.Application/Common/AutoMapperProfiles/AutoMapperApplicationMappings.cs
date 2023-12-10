using AutoMapper;
using ShoppingListApp.Application.Common.DTO;
using ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
using ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateShoppingList;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Common.AutoMapperProfiles;
public sealed class AutoMapperApplicationMappings : Profile
{
    public AutoMapperApplicationMappings()
    {
        CreateMap<ShoppingItemDTO, ShoppingItem>();
        CreateMap<CreateShoppingListRequest, ShoppingList>();
        CreateMap<UpdateShoppingListRequest, ShoppingList>();
        CreateMap<ShoppingItem, ShoppingItem>();
    }
}

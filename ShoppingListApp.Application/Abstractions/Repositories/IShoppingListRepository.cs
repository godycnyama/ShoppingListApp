using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Abstractions.Repositories;
public interface IShoppingListRepository : IGenericRepository<ShoppingList>
{
}
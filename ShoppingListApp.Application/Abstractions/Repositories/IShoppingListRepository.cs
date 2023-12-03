using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Application.Abstractions.Repositories;
public interface IShoppingListRepository : IGenericRepository<ShoppingList>
{
}
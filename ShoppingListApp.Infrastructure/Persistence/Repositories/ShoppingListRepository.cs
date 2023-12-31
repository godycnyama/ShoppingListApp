﻿using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Domain.Entities;
using ShoppingListApp.Infrastructure.Persistence.Context;

namespace ShoppingListApp.Infrastructure.Persistence.Repositories;
public class ShoppingListRepository : GenericRepository<ShoppingList>, IShoppingListRepository
{
    public ShoppingListRepository(ShoppingListAppDataContext dbContext) : base(dbContext)
    {
    }
}

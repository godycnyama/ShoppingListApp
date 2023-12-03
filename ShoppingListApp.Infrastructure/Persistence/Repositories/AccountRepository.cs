using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Domain.Entities;
using ShoppingListApp.Infrastructure.Persistence.Context;

namespace ShoppingListApp.Infrastructure.Persistence.Repositories;
public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(ShoppingListAppDataContext dbContext) : base(dbContext)
    {
    }
}

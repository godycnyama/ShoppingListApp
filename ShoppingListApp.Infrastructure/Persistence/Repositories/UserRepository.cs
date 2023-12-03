using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Domain.Entities;
using ShoppingListApp.Infrastructure.Persistence.Context;
using ShoppingListApp.Infrastructure.Persistence.Repositories;

namespace Roulette.Infrastructure.Persistence.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ShoppingListAppDataContext dbContext) : base(dbContext)
    {
    }
}

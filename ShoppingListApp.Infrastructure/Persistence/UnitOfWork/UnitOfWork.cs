using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Infrastructure.Persistence.Context;

namespace ShoppingListApp.Infrastructure.Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly ShoppingListAppDataContext dbContext;
    public IUserRepository UserRepository { get; }
    public IShoppingListRepository ShoppingListRepository { get; }


    public UnitOfWork(ShoppingListAppDataContext _dbContext, IUserRepository _userRepository, IShoppingListRepository _shoppingListRepository)
    {
        dbContext = _dbContext;
        UserRepository = _userRepository;
        ShoppingListRepository = _shoppingListRepository;
    }

    public void Commit()
        => dbContext.SaveChanges();

    public async Task CommitAsync()
        => await dbContext.SaveChangesAsync();

    public void Rollback()
        => dbContext.Dispose();

    public async Task RollbackAsync()
        => await dbContext.DisposeAsync();
}

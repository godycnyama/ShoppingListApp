using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Infrastructure.Persistence.Context;

namespace ShoppingListApp.Infrastructure.Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly ShoppingListAppDataContext dbContext;
    public IAccountRepository AccountRepository { get; }
    public IShoppingListRepository ShoppingListRepository { get; }


    public UnitOfWork(ShoppingListAppDataContext _dbContext, IAccountRepository _accountRepository, IShoppingListRepository _shoppingListRepository)
    {
        dbContext = _dbContext;
        AccountRepository = _accountRepository;
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

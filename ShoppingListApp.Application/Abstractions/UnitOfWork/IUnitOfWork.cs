using ShoppingListApp.Application.Abstractions.Repositories;

namespace ShoppingListApp.Application.Abstractions.UnitOfWork;
public interface IUnitOfWork
{
    IAccountRepository AccountRepository { get; }
    IShoppingListRepository ShoppingListRepository { get; }
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}

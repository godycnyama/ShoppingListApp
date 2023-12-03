using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Application.Abstractions.Repositories;
using ShoppingListApp.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace ShoppingListApp.Infrastructure.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ShoppingListAppDataContext _dbContext;
    private readonly DbSet<T> _entitiySet;

    public GenericRepository(ShoppingListAppDataContext dbContext)
    {
        _dbContext = dbContext;
        _entitiySet = _dbContext.Set<T>();
    }

    public void Add(T entity)
        => _dbContext.Add(entity);

    public async Task AddAsync(T entity)
        => await _dbContext.AddAsync(entity);

    public void AddRange(IEnumerable<T> entities)
        => _dbContext.AddRange(entities);

    public async Task AddRangeAsync(IEnumerable<T> entities)
        => await _dbContext.AddRangeAsync(entities);

    public T Get(Expression<Func<T, bool>> expression)
        => _entitiySet.FirstOrDefault(expression);

    public async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public IEnumerable<T> GetAll()
        => _entitiySet.AsEnumerable();

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        => _entitiySet.Where(expression).AsEnumerable();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _entitiySet.ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        => await _entitiySet.Where(expression).ToListAsync();


    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        => await _entitiySet.FirstOrDefaultAsync(expression);
    /*
    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
    {
        IQueryable<T> set = _dbContext.Set<T>();

        foreach (var includeExpression in includeExpressions)
        {
            set = set.Include(includeExpression);
        }
        return set;
    }
    */

    public IQueryable<T> Get(params Expression<Func<T, object>>[] includeExpressions)
    {
        return includeExpressions
          .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
           (_dbContext.Set<T>(), (current, expression) => current.Include(expression));
    }

    public void Remove(T entity)
        => _dbContext.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities)
        => _dbContext.RemoveRange(entities);

    public void Update(T entity)
        => _dbContext.Update(entity);

    public void UpdateRange(IEnumerable<T> entities)
        => _dbContext.UpdateRange(entities);
}

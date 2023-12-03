using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Abstractions.Repositories;
public interface IGenericRepository<T> where T : class
{
    T Get(Expression<Func<T, bool>> expression);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    Task<T> GetAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    IQueryable<T> Get(params Expression<Func<T, object>>[] includeExpressions);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
}

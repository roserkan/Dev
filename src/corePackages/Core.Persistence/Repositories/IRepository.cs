using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IRepository<T> where T : Entity
{
    T Get(Expression<Func<T, bool>> predicate);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);


    IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0,
                         int size = 10,
                         bool enableTracking = true);

    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                        int index = 0,
                        int size = 10,
                        bool enableTracking = true,
                        CancellationToken cancellationToken = default);


    IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0, int size = 10, bool enableTracking = true);

    Task<IPaginate<T>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0,
                         int size = 10,
                         bool enableTracking = true,
                         CancellationToken cancellationToken = default);


    T Add(T entity);
    Task<T> AddAsync(T entity);

    T Update(T entity);
    Task<T> UpdateAsync(T entity);

    T Delete(T entity);
    Task<T> DeleteAsync(T entity);
}
using System.Linq.Expressions;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public class EFRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    private readonly DbContext dbContext;
    protected DbSet<TEntity> _entity => dbContext.Set<TEntity>();

    public EFRepository(DbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _entity.FirstOrDefault(predicate);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable.Where(predicate);
        if (include != null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync();

        //return await _entity.FirstOrDefaultAsync();

    }

    public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable).ToPaginate(index, size);
        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public TEntity Add(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Added;
        dbContext.SaveChanges();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Added;
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        dbContext.SaveChanges();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Deleted;
        dbContext.SaveChanges();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Deleted;
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> Query()
    {
        return _entity;
    }
}
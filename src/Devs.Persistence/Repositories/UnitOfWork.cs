using Core.Persistence.Repositories;
using Devs.Application.Interfaces.Repositories;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DevsContext _dbContext;

    public UnitOfWork(DevsContext dbContext)
    {

        if (dbContext == null)
            throw new ArgumentNullException("dbContext can not be null.");

        _dbContext = dbContext;

        //_dbContext.Configuration.LazyLoadingEnabled = false;
        //_dbContext.Configuration.ValidateOnSaveEnabled = false;
        //_dbContext.Configuration.ProxyCreationEnabled = false;
    }

    #region IUnitOfWork Members
    public IRepository<T> GetRepository<T>() where T : Entity
    {
        return new EFRepository<T>(_dbContext);
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
            // sadece değişen alanları güncellemeyide sağlayabiliriz.
            return await _dbContext.SaveChangesAsync();
        }
        catch
        {
            // Burada DbEntityValidationException hatalarını handle edebiliriz.
            throw;
        }
    }

    public int SaveChanges()
    {
        try
        {
            // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
            // sadece değişen alanları güncellemeyide sağlayabiliriz.
            return _dbContext.SaveChanges();
        }
        catch
        {
            // Burada DbEntityValidationException hatalarını handle edebiliriz.
            throw;
        }
    }
    #endregion

    #region IDisposable Members
    // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion


}
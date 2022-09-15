using Core.Persistence.Repositories;

namespace Devs.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : Entity;
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
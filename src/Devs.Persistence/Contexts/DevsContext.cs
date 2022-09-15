using Core.Persistence.Repositories;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Devs.Persistence.Contexts;

public class DevsContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    public DevsContext()
    {

    }

    public DevsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Eğer konfigure edilmediyse burası çalışır. Normal şartlarda buraya girmez!!
        //if (!optionsBuilder.IsConfigured)
        //{
        //    var connStr = "Server=localhost,1433;Database=devs;User Id=sa;Password=P455w0rD;";
        //    optionsBuilder.UseSqlServer(connStr, opt =>
        //    {
        //        opt.EnableRetryOnFailure();
        //    });
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }


    private void OnBeforeSave()
    {
        var addedEntites = ChangeTracker.Entries()
                                .Where(i => i.State == EntityState.Added)
                                .Select(i => (Entity)i.Entity);

        PrepareAddedEntities(addedEntites);
    }

    private void PrepareAddedEntities(IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.CreatedDate == DateTime.MinValue)
                entity.CreatedDate = DateTime.Now;
        }
    }
}
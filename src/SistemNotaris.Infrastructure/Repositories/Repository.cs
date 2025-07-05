using Microsoft.EntityFrameworkCore;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TId>
    where TEntity : Entity<TId>
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public async Task<TEntity?> GetByIdAsync(
        TId id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id.Equals(id) , cancellationToken); // This will use 'Guid' if T is Customer
    }
    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }

}
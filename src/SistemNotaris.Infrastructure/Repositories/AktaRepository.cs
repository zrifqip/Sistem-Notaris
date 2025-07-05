using Microsoft.EntityFrameworkCore;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;

namespace SistemNotaris.Infrastructure.Repositories;

internal sealed class AktaRepository : Repository<Akta, Guid>, IAktaRepository
{
    public AktaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public void Delete(Akta akta)
    {
        DbContext.Remove(akta);
    }
    public async Task<List<Akta>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Akta>()
            .ToListAsync(cancellationToken);
    }
}
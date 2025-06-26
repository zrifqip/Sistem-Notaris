using Microsoft.EntityFrameworkCore;
using SistemNotaris.Domain.Client;

namespace SistemNotaris.Infrastructure.Repositories;

internal sealed class ClientRepository : Repository<Clients, string>, IClientRepository
{
    public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<Clients>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Clients>()
            .ToListAsync(cancellationToken);
    }

    public void Update(Clients client)
    {
        DbContext.Update(client);
    }
}
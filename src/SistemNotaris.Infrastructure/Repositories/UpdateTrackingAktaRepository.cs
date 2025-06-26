using Microsoft.EntityFrameworkCore;
using SistemNotaris.Domain.UpdateAkta;

namespace SistemNotaris.Infrastructure.Repositories;

internal sealed class UpdateTrackingAktaRepository : Repository<TrackingUpdate, Guid>, IUpdateAktaRepository
{
    public UpdateTrackingAktaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<TrackingUpdate>> GetByIdTracking(Guid trackingId)
    {
        return await DbContext
            .Set<TrackingUpdate>()
            .Where(x => x.TrackingId == trackingId)
            .ToListAsync();
    }
    
}
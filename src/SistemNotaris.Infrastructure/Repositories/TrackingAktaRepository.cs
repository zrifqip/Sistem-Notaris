using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Infrastructure.Repositories;

internal sealed class TrackingAktaRepository : Repository<TrackingAkta, Guid>, ITrackingAktaRepository
{
    public TrackingAktaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    public void Update(TrackingAkta akta)
    {
        DbContext.Update(akta);
    }
}
namespace SistemNotaris.Domain.UpdateAkta;

public interface IUpdateAktaRepository
{
    void Add(TrackingUpdate trackingUpdate);
    Task<List<TrackingUpdate>> GetByIdTracking(Guid trackingId);
}
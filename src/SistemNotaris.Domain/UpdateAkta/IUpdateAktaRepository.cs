namespace SistemNotaris.Domain.UpdateAkta;

public interface IUpdateAktaRepository
{
    void Add(TrackingUpdate trackingUpdate);
    Task<TrackingUpdate[]> GetByTrackingIdAsync(Guid trackingId);
}
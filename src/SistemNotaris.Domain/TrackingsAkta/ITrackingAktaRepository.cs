namespace SistemNotaris.Domain.TrackingsAkta;

public interface ITrackingAktaRepository
{
    void Add(TrackingAkta akta);
    void Update(TrackingAkta akta);
    Task<TrackingAkta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
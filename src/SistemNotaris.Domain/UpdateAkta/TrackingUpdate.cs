using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Abstraction.Entity;
using SistemNotaris.Domain.Shared;
using SistemNotaris.Domain.UpdateAkta.Events;

namespace SistemNotaris.Domain.UpdateAkta;

public class TrackingUpdate : Entity<Guid>
{
    private TrackingUpdate(
        Guid id,
        Guid trackingId,
        Guid idKaryawan,
        Deskripsi deskripsiPengerjaan,
        DateTime createdAt
    ) : base(id)
    {
        Id = id;
        TrackingId = trackingId;
        IdKaryawan = idKaryawan;
        DeskripsiPengerjaan = deskripsiPengerjaan;
        CreatedAt = createdAt;
    }

    public Guid TrackingId { get; private set; }
    public Guid IdKaryawan { get; private set; }
    public Deskripsi DeskripsiPengerjaan { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static TrackingUpdate Create(
        Guid trackingId,
        Guid idKaryawan,
        Deskripsi deskripsiPengerjaan,
        DateTime createdAt
    )
    {
        var createTrackingUpdate = new TrackingUpdate(
            Guid.NewGuid(),
            trackingId,
            idKaryawan,
            deskripsiPengerjaan,
            createdAt
        );
        createTrackingUpdate.RaiseDomainEvent(new UpdateCreatedDomainEvent(createTrackingUpdate.Id));
        return createTrackingUpdate;
    }
}
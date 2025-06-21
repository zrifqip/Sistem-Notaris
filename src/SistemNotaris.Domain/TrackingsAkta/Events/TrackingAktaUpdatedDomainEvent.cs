using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.TrackingsAkta.Events;

public sealed record TrackingAktaUpdatedDomainEvent(Guid TrackingId, Guid KaryawanId) : IDomainEvent;
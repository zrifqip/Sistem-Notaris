using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.TrackingsAkta.Events;

public sealed record TrackingAktaCancelledDomainEvent(Guid TrackingId) : IDomainEvent;
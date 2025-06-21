using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.TrackingsAkta.Events;

public sealed record TrackingAktaCompletedDomainEvent(Guid TrackingId) : IDomainEvent;
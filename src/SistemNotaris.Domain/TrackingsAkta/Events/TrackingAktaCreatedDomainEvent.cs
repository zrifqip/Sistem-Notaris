using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.TrackingsAkta.Events;

public sealed record TrackingAktaCreatedDomainEvent(Guid TrackingId) : IDomainEvent;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.UpdateAkta.Events;

public sealed record UpdateCreatedDomainEvent(Guid UpdateId) : IDomainEvent;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Akta.Events;

public sealed record AktaCreatedDomainEvent(Guid Id) : IDomainEvent;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Akta.Events;

public sealed record AktaDeletedDomainEvent(Guid Id) : IDomainEvent;
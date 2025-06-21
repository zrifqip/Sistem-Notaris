using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Akta.Events;

public sealed record AktaUpdatedDomainEvent(Guid Id) : IDomainEvent;
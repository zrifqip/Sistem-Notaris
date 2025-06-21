using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Client.Events;

public sealed record ClientCreatedDomainEvent(string NIK) : IDomainEvent;
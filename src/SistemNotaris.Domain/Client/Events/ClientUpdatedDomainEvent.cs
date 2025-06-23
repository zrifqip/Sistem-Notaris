using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Client.Events;

public sealed record ClientUpdatedDomainEvent(string NIK) : IDomainEvent;

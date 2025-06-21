using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Karyawan.Events;

public sealed record KaryawanCreatedDomainEvent(Guid Id) : IDomainEvent;
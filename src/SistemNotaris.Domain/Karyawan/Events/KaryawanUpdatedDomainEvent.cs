using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Karyawan.Events;

public record KaryawanUpdatedDomainEvent(Guid Id) : IDomainEvent;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.GetKaryawan;

public record GetKaryawanQuery(Guid IdKaryawan) : IQuery<KaryawanResponse>;

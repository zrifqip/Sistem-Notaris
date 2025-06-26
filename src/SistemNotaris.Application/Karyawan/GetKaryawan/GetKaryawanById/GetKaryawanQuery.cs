using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Application.Karyawan.GetKaryawan.SearchKaryawan;

namespace SistemNotaris.Application.Karyawan.GetKaryawan.GetKaryawanById;

public record GetKaryawanQuery(Guid IdKaryawan) : IQuery<KaryawanResponse>;

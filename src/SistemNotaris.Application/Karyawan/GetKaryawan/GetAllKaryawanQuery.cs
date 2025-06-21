using SistemNotaris.Application.Abstraction.Messaging;

namespace SistemNotaris.Application.Karyawan.GetKaryawan;

public record GetAllKaryawanQuery() : IQuery<IReadOnlyList<KaryawanResponse>>;

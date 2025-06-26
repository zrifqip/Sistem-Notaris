using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.Karyawan.GetKaryawan.SearchKaryawan;

public sealed record SearchKaryawanByNameQuery(Nama? Name) : IQuery<KaryawanResponse>;
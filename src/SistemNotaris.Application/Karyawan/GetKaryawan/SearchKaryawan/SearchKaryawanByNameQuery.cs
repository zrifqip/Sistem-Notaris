using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Application.Karyawan.GetKaryawan;
using SistemNotaris.Domain.Shared;

public sealed record SearchKaryawanByNameQuery(Nama? Name) : IQuery<KaryawanResponse>;
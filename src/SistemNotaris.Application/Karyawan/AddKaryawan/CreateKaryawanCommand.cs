using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.Karyawan.AddKaryawan;

public record CreateKaryawanCommand(Nama Nama, NoTelfon NoTelfon) : ICommand<Guid>;
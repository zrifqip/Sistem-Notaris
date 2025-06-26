using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.UpdateKaryawanRecord;

public sealed record UpdateKaryawanCommand(Guid Id) : ICommand;
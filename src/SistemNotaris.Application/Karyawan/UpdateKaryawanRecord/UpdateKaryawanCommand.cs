using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.UpdateKaryawanRecord;

public record UpdateKaryawanCommand(
    Guid Id,
    RecordPengerjaan Record
    ) : ICommand;
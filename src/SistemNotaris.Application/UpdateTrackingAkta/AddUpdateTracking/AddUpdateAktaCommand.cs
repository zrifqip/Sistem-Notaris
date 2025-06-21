using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.UpdateTrackingAkta.AddUpdateTracking;

public record AddUpdateAktaCommand(
    Guid IdTrackingAkta, 
    DateTime Tanggal,
    Guid IdKaryawan,
    Deskripsi Keterangan
    ) : ICommand<Guid>;
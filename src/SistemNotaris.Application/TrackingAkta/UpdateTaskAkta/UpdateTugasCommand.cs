using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.TrackingAkta.UpdateTaskAkta;

public record UpdateTugasCommand(Guid TrackingAktaId, Guid KaryawanId, Deskripsi TugasSekarang) : ICommand;
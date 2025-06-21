using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.TrackingAkta.TambahAkta;

public record TambahAktaCommand(
    Guid AktaId,
    Guid KaryawanId,
    Deskripsi DeskripsiAkta
) : ICommand<Guid>;
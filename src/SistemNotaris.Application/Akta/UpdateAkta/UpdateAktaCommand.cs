using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.Akta.UpdateAkta;

public record UpdateAktaCommand(
    Guid Id,
    Nama NamaAkta,
    string ClientId,
    JenisAkta JenisAkta
    ) : ICommand;

using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.Akta.CreateAkta;

public sealed record CreateAktaCommand(
    string Nik,
    Nama NamaAkta,
    JenisAkta JenisAkta
) : ICommand<Guid>;

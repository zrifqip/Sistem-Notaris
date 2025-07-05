using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Application.Client.UpdateClient;

public sealed record UpdateClientCommand(
    string NIK,
    string Nama,
    string AlamatLengkap,
    string Kecamatan,
    string Kelurahan,
    string KodePos,
    string NoTelfon,
    string NamaBank,
    string NoRekening
    ) : ICommand;

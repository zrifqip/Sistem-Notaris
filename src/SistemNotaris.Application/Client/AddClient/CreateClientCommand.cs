using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Application.Client.AddClient;

public sealed record CreateClientCommand(
    string Nik,
    string Nama,
    string AlamatLengkap,
    string Kecamatan,
    string Kelurahan,
    string KodePos,
    string NoTelfon,
    string NamaBank,
    string NoRekening
    ) : ICommand<string>;

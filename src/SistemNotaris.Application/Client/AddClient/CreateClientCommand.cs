using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Shared;
using SistemNotaris.Domain.Client;

namespace SistemNotaris.Application.Client.AddClient;

public sealed record CreateClientCommand(
    string Nik,
    Nama Nama,
    Alamat Alamat,
    NoTelfon NoTelfon
    ) : ICommand<string>;

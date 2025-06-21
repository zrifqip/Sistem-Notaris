using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Client.Events;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Domain.Client;

public class Clients : Entity<string>
{
    private Clients(
        string NIK,
        Nama nama,
        Alamat alamat,
        NoTelfon noTelfon
    ) : base(NIK)
    {
        Id = NIK;
        Nama = nama;
        Alamat = alamat;
        NoTelfon = noTelfon;
    }

    public Nama Nama { get; private set; }
    public Alamat Alamat { get; private set; }
    public NoTelfon NoTelfon { get; private set; }

    public static Clients Create(string NIK, Nama nama, Alamat alamat, NoTelfon noTelfon)
    {
        var client = new Clients(NIK, nama, alamat, noTelfon);
        client.RaiseDomainEvent(new ClientCreatedDomainEvent(NIK));
        return client;
    }
}
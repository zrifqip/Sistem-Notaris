using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Client.Events;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Domain.Client;

public class Clients : Entity<string>
{ 

    private Clients(
        string nik,
        Nama nama,
        Alamat alamat,
        NoTelfon noTelfon,
        InfoBank infoBank
    ) : base(nik)
    {
        Id = nik;
        Nama = nama;
        Alamat = alamat;
        NoTelfon = noTelfon;
        InfoBank = infoBank;
    }
    private Clients() : base(string.Empty)
    {
    }
    public Nama Nama { get; private set; }
    public Alamat Alamat { get; private set; }
    public NoTelfon NoTelfon { get; private set; }
    public InfoBank InfoBank { get; private set; }

    public static Clients Create(string nik, Nama nama, Alamat alamat, NoTelfon noTelfon, InfoBank infoBank)
    {
        var client = new Clients(nik, nama, alamat, noTelfon, infoBank);
        client.RaiseDomainEvent(new ClientCreatedDomainEvent(nik));
        return client;
    }

    public Result Update(Nama nama, Alamat alamat, NoTelfon noTelfon,InfoBank infoBank)
    {
        if (Id == string.Empty) return Result.Failure(ClientError.NotFound);
        Nama = nama;
        Alamat = alamat;
        NoTelfon = noTelfon;
        InfoBank = infoBank;
        RaiseDomainEvent(new ClientUpdatedDomainEvent(Id));
        return Result.Success();
    }
}
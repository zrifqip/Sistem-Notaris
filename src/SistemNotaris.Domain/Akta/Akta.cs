using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta.Events;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Domain.Akta;

public class Akta : Entity<Guid>
{
    public Akta(Guid id, Nama namaAkta, string clientId, JenisAkta jenisAkta, DateTime? tanggalSelesai = null)
        : base(id)
    {
        NamaAkta = namaAkta;
        ClientId = clientId;
        JenisAkta = jenisAkta;
        TanggalSelesai = tanggalSelesai;
    }

    public Nama NamaAkta { get;}
    public string ClientId { get; }
    public JenisAkta JenisAkta { get; }
    public DateTime? TanggalSelesai { get; }

    public static Akta Create(
        string clientId,
        Nama namaAkta,
        JenisAkta jenisAkta,
        DateTime? tanggalSelesai = null
    )
    {
        var akta = new Akta(Guid.NewGuid(), namaAkta, clientId, jenisAkta, tanggalSelesai);
        akta.RaiseDomainEvent(new AktaCreatedDomainEvent(akta.Id));
        return akta;
    }

    public Result Update(Akta akta)
    {
        if (Id != akta.Id) return Result.Failure(AktaError.NotFound);
        var updatedAkta = new Akta(
            akta.Id,
            akta.NamaAkta,
            akta.ClientId,
            akta.JenisAkta,
            akta.TanggalSelesai
        );
        updatedAkta.RaiseDomainEvent(new AktaUpdatedDomainEvent(updatedAkta.Id));
        return Result.Success();
    }

    public Result Delete(Guid id)
    {
        if (Id != id) return Result.Failure(AktaError.NotFound);
        RaiseDomainEvent(new AktaDeletedDomainEvent(Id));
        return Result.Success();
    }
}
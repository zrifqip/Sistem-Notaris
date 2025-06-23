using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Shared;
using SistemNotaris.Domain.TrackingsAkta.Events;

namespace SistemNotaris.Domain.TrackingsAkta;

public sealed class TrackingAkta : Entity<Guid>
{
    private TrackingAkta(
        Guid id,
        Guid idAkta,
        ProgresStatus status,
        Guid idKaryawanSaatIni,
        Deskripsi tugasSekarang,
        DateTime createdAt,
        DateTime? finishedAt = null
    ) : base(id)
    {
        Id = id;
        IdAkta = idAkta;
        Status = status;
        IdKaryawanSaatini = idKaryawanSaatIni;
        TugasSekarang = tugasSekarang;
        CreatedAt = createdAt;
        FinishedAt = finishedAt;
    }

    public Guid IdAkta { get; private set; }
    public Guid IdKaryawanSaatini { get; private set; }
    public ProgresStatus Status { get; private set; }
    public Deskripsi TugasSekarang { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }

    public static TrackingAkta CreateAkta(
        Guid idAkta,
        Guid idKaryawanSaatini,
        Deskripsi tugasSekarang,
        DateTime wibTime
    )
    {
        var status = ProgresStatus.Dikerjakan;
        var trackingAkta = new TrackingAkta(
            Guid.NewGuid(),
            idAkta,
            status,
            idKaryawanSaatini,
            tugasSekarang,
            wibTime
        );
        trackingAkta.RaiseDomainEvent(new TrackingAktaCreatedDomainEvent(trackingAkta.Id));
        return trackingAkta;
    }

    public Result CompleteAkta(DateTime wibTime)
    {
        if (Status != ProgresStatus.Dikerjakan) return Result.Failure(TrackingAktaError.Inactive);
        Status = ProgresStatus.Selesai;
        FinishedAt = wibTime;
        RaiseDomainEvent(new TrackingAktaCompletedDomainEvent(Id));
        return Result.Success();
    }

    public Result CancelAkta(DateTime wibTime)
    {
        if (Status != ProgresStatus.Dikerjakan) return Result.Failure(TrackingAktaError.Inactive);
        Status = ProgresStatus.Dibatalkan;
        FinishedAt = wibTime;
        RaiseDomainEvent(new TrackingAktaCancelledDomainEvent(Id));
        return Result.Success();
    }

    public Result Update(Guid karyawanId, Deskripsi tugasSekarang)
    {
        if (Status != ProgresStatus.Dikerjakan)
        {
            return Result.Failure(TrackingAktaError.Inactive);
        }
        IdKaryawanSaatini = karyawanId;
        TugasSekarang = tugasSekarang;

        RaiseDomainEvent(new TrackingAktaUpdatedDomainEvent(Id, karyawanId));
        
        return Result.Success();
    }
}
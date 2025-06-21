using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Karyawan.Events;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Domain.Karyawan;

public class Karyawans : Entity<Guid>
{
    private Karyawans(Guid id, Nama nama,NoTelfon noTelfon, LoginStatus loginStatus, RecordPengerjaan record) : base(id)
    {
        Id = id;
        Nama = nama;
        NoTelfon = noTelfon;
        LoginStatus = loginStatus;
        Record = record;
    }

    public Nama Nama { get; private set; }
    public NoTelfon NoTelfon { get; private set; }
    public LoginStatus LoginStatus { get; private set; }
    public RecordPengerjaan Record { get; private set; }

    public static Karyawans Create(Nama nama, NoTelfon noTelfon)
    {
        var id = Guid.NewGuid();
        var loginStatus = LoginStatus.Create();
        var record = RecordPengerjaan.Create();
        var karyawan = new Karyawans(id, nama, noTelfon, loginStatus, record);
        karyawan.RaiseDomainEvent(new KaryawanCreatedDomainEvent(id));
        return karyawan;
    }
    /*public static Result<IncrementRecordPengerjaan>(Karyawans karyawan)
    {
        karyawan.Record = karyawan.Record.Increment();
    }

    public static void SetOnline(Karyawans karyawan)
    {

    }*/
}
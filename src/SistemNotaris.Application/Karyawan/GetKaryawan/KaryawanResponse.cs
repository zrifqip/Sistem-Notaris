using SistemNotaris.Domain.Karyawan;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.Karyawan.GetKaryawan;

public class KaryawanResponse
{
    public Guid Id { get; set; }
    public Nama Nama { get; set; }
    public NoTelfon NoTelfon { get; set; }
    public LoginStatus LoginStatus { get; set; }
    public RecordPengerjaan Record { get; set; }
}
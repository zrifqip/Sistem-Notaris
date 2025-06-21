using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.UpdateAkta;

public class TrackingUpdateError
{
    public static Error NotFound = new(
        "UpdateAkta.Found",
        "Events tidak ditemukan");

    public static Error NotAuthorized = new
    (
        "UpdateAkta.NotAuthorized",
        "Karyawan tidak dapat mengakses akta ini"
    );
}
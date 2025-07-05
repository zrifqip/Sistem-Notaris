using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.UpdateAkta;

public class TrackingUpdateError
{
    public static Error NotFound = new(
        "TrackingUpdateAkta.Found",
        "Events tidak ditemukan");

    public static Error NotAuthorized = new
    (
        "TrackingUpdateAkta.NotAuthorized",
        "Karyawan tidak dapat mengakses akta ini"
    );
}
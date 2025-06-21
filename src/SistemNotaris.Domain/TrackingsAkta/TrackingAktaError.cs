using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.TrackingsAkta;

public class TrackingAktaError
{
    public static Error NotFound = new(
        "TrackingsAkta.Found",
        "Events tidak ditemukan");

    public static Error Inactive = new
    (
        "TrackingsAkta.Inactive",
        "Events sedang tidak aktif"
    );
}
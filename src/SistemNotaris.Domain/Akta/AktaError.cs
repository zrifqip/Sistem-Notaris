using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Akta;

public class AktaError
{
    public static Error NotFound = new(
        "Karyawan.Found",
        "Karyawan tidak ditemukan");

    public static Error InvalidAktaType = new(
        "Akta.InvalidAktaType",
        "Tipe akta tidak valid"
    );
}
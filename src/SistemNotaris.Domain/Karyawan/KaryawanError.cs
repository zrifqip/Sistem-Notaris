using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Karyawan;

public class KaryawanError
{
    public static Error NotFound = new(
        "Karyawan.Found",
        "Karyawan tidak ditemukan");

    public static Error InvalidCredentials = new(
        "Karyawan.InvalidCredentials",
        "Kredensial tidak valid");
}
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Domain.Client;

public class ClientError
{
    public static Error NotFound = new(
        "ClientsError.NotFound",
        "Client tidak ditemukan");

    public static Error AlreadyExist = new(
        "ClientsError.AlreadyExists",
        "Client sudah terdaftar");

    public static Error InvalidNik = new(
        "ClientsError.InvalidNIK",
        "NIK tidak valid");
}
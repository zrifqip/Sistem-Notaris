namespace SistemNotaris.Domain.Client;

public record Alamat(
    string AlamatLengkap,
    string Kecamatan,
    string Kelurahan,
    string KodePos
);
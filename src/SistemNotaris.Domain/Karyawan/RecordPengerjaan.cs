namespace SistemNotaris.Domain.Karyawan;

public sealed record RecordPengerjaan
{
    private RecordPengerjaan(int jumlahPengerjaan)
    {
        JumlahPengerjaan = jumlahPengerjaan;
    }

    public int JumlahPengerjaan { get; private init; }

    public static RecordPengerjaan Create()
    {
        return new RecordPengerjaan(0);
    }

    public RecordPengerjaan Increment()
    {
        return this with { JumlahPengerjaan = JumlahPengerjaan + 1 };
    }
}
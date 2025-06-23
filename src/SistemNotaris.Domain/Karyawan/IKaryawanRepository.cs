namespace SistemNotaris.Domain.Karyawan;

public interface IKaryawanRepository
{
    Task<Karyawans?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Update(Karyawans karyawan);
    void Add(Karyawans karyawan);
}
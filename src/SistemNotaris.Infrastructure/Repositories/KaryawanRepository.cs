using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Infrastructure.Repositories;

internal sealed class KaryawanRepository : Repository<Karyawans, Guid>, IKaryawanRepository
{
    public KaryawanRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public void Update(Karyawans karyawan)
    {
        DbContext.Update(karyawan);
    }
}
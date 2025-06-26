namespace SistemNotaris.Domain.Akta;

public interface IAktaRepository
{
    void Add(Akta akta);
    void Delete(Akta akta);
    Task<Akta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Akta>> GetAllAsync(CancellationToken cancellationToken = default);
}
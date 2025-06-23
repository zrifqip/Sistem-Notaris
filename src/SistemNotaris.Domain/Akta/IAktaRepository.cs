namespace SistemNotaris.Domain.Akta;

public interface IAktaRepository
{
    void AddAKta(Akta akta);
    void DeleteAkta(Akta akta);
    Task<Akta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Akta[]> GetAllAsync(CancellationToken cancellationToken = default);
}
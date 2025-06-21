namespace SistemNotaris.Domain.Akta;

public interface IAktaRepository
{
    void AddAKta(Akta akta);
    void DeleteAkta(Guid id);
    Task<Akta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Akta[]> GetAllAsync(CancellationToken cancellationToken = default);
}
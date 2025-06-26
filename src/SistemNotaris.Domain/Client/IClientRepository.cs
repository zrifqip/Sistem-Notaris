namespace SistemNotaris.Domain.Client;

public interface IClientRepository
{
    void Add(Clients client);
    Task<List<Clients>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Clients?> GetByIdAsync(string nik, CancellationToken cancellationToken = default);
    void Update(Clients client);
}
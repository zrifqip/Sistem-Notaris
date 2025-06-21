using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Application.Client.AddClient;

internal sealed class CreateClientCommandHandler : ICommandHandler<CreateClientCommand, string>
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClientCommandHandler(
        IClientRepository clientRepository,
        IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(
        CreateClientCommand request,
        CancellationToken cancellationToken)
    {
        var client = Clients.Create(
            request.Nik,
            request.Nama,
            request.Alamat,
            request.NoTelfon);

        _clientRepository.Add(client);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(client.Id);
    }
}

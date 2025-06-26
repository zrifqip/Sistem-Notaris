using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Shared;

namespace SistemNotaris.Application.Client.AddClient;

internal sealed class CreateClientCommandHandler : ICommandHandler<CreateClientCommand,string>
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

    public async Task<Result<string>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var address = new Alamat(
            request.AlamatLengkap,
            request.Kecamatan,
            request.Kelurahan,
            request.KodePos
        );
        var nama = new Nama(request.Nama);
        var noTelfon = new NoTelfon(request.NoTelfon);
        var client = Clients.Create(
            request.Nik,
            nama,
            address,
            noTelfon
        );
        _clientRepository.Add(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(client.Id);
    }
}

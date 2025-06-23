using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Shared;
using Dapper;

namespace SistemNotaris.Application.Client.UpdateClient;

internal sealed class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientCommandHandler(
        IClientRepository clientRepository,
        IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetByIdAsync(request.NIK, cancellationToken);
        if (client == null)
        {
            return Result.Failure(ClientError.NotFound);
        }
        var address = new Alamat(
            request.AlamatLengkap,
            request.Kecamatan,
            request.Kelurahan,
            request.KodePos
        );
        var nama = new Nama(request.Nama);
        var noTelfon = new NoTelfon(request.NoTelfon);
        var result = client.Update(
            nama,
            address,
            noTelfon
        );

        if (result.IsFailure)
        {
            return result;
        }

        _clientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}

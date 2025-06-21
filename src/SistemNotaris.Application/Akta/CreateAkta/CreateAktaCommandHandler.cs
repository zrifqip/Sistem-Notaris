using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Client;

namespace SistemNotaris.Application.Akta.CreateAkta;

internal sealed class CreateAktaCommandHandler : ICommandHandler<CreateAktaCommand, Guid>
{
    private readonly IAktaRepository _aktaRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAktaCommandHandler(
        IUnitOfWork unitOfWork,
        IAktaRepository aktaRepository,
        IClientRepository clientRepository)
    {
        _unitOfWork = unitOfWork;
        _aktaRepository = aktaRepository;
        _clientRepository = clientRepository;
    }

    public async Task<Result<Guid>> Handle(CreateAktaCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetByIdAsync(request.Nik, cancellationToken);
        if (client is null)
        {
            return Result.Failure<Guid>(ClientError.NotFound);        
        }

        var akta = Domain.Akta.Akta.Create(
            client.Id,
            request.NamaAkta,
            request.JenisAkta
        );
        _aktaRepository.AddAKta(akta);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(akta.Id);
    }
}
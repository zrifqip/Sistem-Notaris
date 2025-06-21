using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;

namespace SistemNotaris.Application.Akta.UpdateAkta;

internal sealed class UpdateAktaCommandHandler : ICommandHandler<UpdateAktaCommand>
{
    private readonly IAktaRepository _aktaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAktaCommandHandler(IAktaRepository aktaRepository, IUnitOfWork unitOfWork)
    {
        _aktaRepository = aktaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAktaCommand request, CancellationToken cancellationToken)
    {
        var akta = await _aktaRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (akta is null)
        {
            return Result.Failure(AktaError.NotFound);
        }

        var updatedAkta = new Domain.Akta.Akta(
            request.Id,
            request.NamaAkta,
            request.ClientId,
            request.JenisAkta
            );

        var result = akta.Update(updatedAkta);
        
        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
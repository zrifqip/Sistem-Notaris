using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;

namespace SistemNotaris.Application.Akta.DeleteAkta;

internal sealed class DeleteAktaCommandHandler : ICommandHandler<DeleteAktaCommand>
{
    private readonly IAktaRepository _aktaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAktaCommandHandler(
        IAktaRepository aktaRepository,
        IUnitOfWork unitOfWork)
    {
        _aktaRepository = aktaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        DeleteAktaCommand request,
        CancellationToken cancellationToken)
    {
        var akta = await _aktaRepository.GetByIdAsync(request.Id, cancellationToken);

        if (akta is null)
        {
            return Result.Failure(AktaError.NotFound);
        }

        var result = akta.Delete(request.Id);
        
        if (result.IsFailure)
        {
            return result;
        }
        _aktaRepository.Delete(akta);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
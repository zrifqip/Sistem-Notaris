using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.CompleteAkta;

internal sealed class CompleteAktaCommandHandler : ICommandHandler<CompleteAktaCommand>
{
    private readonly ITrackingAktaRepository _trackingAktaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteAktaCommandHandler(
        IUnitOfWork unitOfWork,
        ITrackingAktaRepository trackingAktaRepository
        )
    {
        _unitOfWork = unitOfWork;
        _trackingAktaRepository = trackingAktaRepository;
    }

    public async Task<Result> Handle(CompleteAktaCommand request, CancellationToken cancellationToken)
    {
        var trackingAkta = await _trackingAktaRepository.GetByIdAsync(request.TrackingAktaId, cancellationToken);
        if (trackingAkta is null)
            return Result.Failure<Guid>(TrackingAktaError.NotFound);

        var result = trackingAkta.CompleteAkta(DateTime.Now);
        if (result.IsFailure) return result;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
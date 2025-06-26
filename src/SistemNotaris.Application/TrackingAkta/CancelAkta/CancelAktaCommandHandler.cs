using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.CancelAkta;

internal sealed class CancelAktaCommandHandler : ICommandHandler<CancelAktaCommand>
{
    private readonly ITrackingAktaRepository _trackingAktaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelAktaCommandHandler(
        IUnitOfWork unitOfWork,
        ITrackingAktaRepository trackingAktaRepository
        )
    {
        _unitOfWork = unitOfWork;
        _trackingAktaRepository = trackingAktaRepository;
    }

    public async Task<Result> Handle(CancelAktaCommand request, CancellationToken cancellationToken)
    {
        var trackingAkta = await _trackingAktaRepository.GetByIdAsync(request.TrackingId, cancellationToken);
        if (trackingAkta is null) return Result.Failure<Guid>(TrackingAktaError.NotFound);
        
        var result = trackingAkta.CancelAkta(DateTime.Now);
        
        if (result.IsFailure) return result;
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
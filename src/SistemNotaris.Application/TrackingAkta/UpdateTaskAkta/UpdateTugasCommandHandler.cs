using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.UpdateTaskAkta;

internal sealed class UpdateTugasCommandHandler : ICommandHandler<UpdateTugasCommand>
{
    private readonly ITrackingAktaRepository _trackingAktaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTugasCommandHandler(
        ITrackingAktaRepository trackingAktaRepository,
        IUnitOfWork unitOfWork)
    {
        _trackingAktaRepository = trackingAktaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateTugasCommand request,
        CancellationToken cancellationToken)
    {
        var tracking = await _trackingAktaRepository.GetByIdAsync(
            request.TrackingAktaId,
            cancellationToken);

        if (tracking is null)
        {
            return Result.Failure(TrackingAktaError.NotFound);
        }

        var result = tracking.Update(
            request.KaryawanId,
            request.TugasSekarang
            );

        if (result.IsFailure)
        {
            return result;
        }

        _trackingAktaRepository.Update(tracking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

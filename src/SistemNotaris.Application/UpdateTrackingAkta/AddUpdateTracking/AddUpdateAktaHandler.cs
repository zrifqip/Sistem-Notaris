using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.TrackingsAkta;
using SistemNotaris.Domain.UpdateAkta;

namespace SistemNotaris.Application.UpdateTrackingAkta.AddUpdateTracking;

internal sealed class AddUpdateAktaHandler : ICommandHandler<AddUpdateAktaCommand, Guid>
{
    private readonly IUpdateAktaRepository _updateAktaRepository;
    private readonly ITrackingAktaRepository _trackingAktaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddUpdateAktaHandler(
        IUnitOfWork unitOfWork,
        IUpdateAktaRepository updateAktaRepository,
        ITrackingAktaRepository trackingAktaRepository)
    {
        _unitOfWork = unitOfWork;
        _updateAktaRepository = updateAktaRepository;
        _trackingAktaRepository = trackingAktaRepository;
    }

    public async Task<Result<Guid>> Handle(AddUpdateAktaCommand request, CancellationToken cancellationToken)
    {
        var trackingAkta = await _trackingAktaRepository.GetByIdAsync(request.IdTrackingAkta, cancellationToken);
        if (trackingAkta is null)
            return Result.Failure<Guid>(TrackingAktaError.NotFound);
        
        var updateAkta = TrackingUpdate.Create(
            request.IdTrackingAkta,
            request.IdKaryawan,
            request.Keterangan,
            request.Tanggal
        );
        _updateAktaRepository.Add(updateAkta);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(updateAkta.Id);
    }
}
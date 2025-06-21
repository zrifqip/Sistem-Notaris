using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Karyawan;
using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.TambahAkta;

internal sealed class TambahAktaCommandHandler : ICommandHandler<TambahAktaCommand, Guid>
{
    private readonly IAktaRepository _aktaRepository;
    private readonly IKaryawanRepository _karyawanRepository;
    private readonly ITrackingAktaRepository _trackingAktaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TambahAktaCommandHandler(
        IUnitOfWork unitOfWork,
        IClientRepository clientRepository,
        ITrackingAktaRepository trackingAktaRepository,
        IAktaRepository aktaRepository,
        IKaryawanRepository karyawanRepository)
    {
        _unitOfWork = unitOfWork;
        _trackingAktaRepository = trackingAktaRepository;
        _aktaRepository = aktaRepository;
        _karyawanRepository = karyawanRepository;
    }

    public async Task<Result<Guid>> Handle(TambahAktaCommand request, CancellationToken cancellationToken)
    {
        var akta = await _aktaRepository.GetByIdAsync(request.AktaId, cancellationToken);
        if (akta is null)
            return Result.Failure<Guid>(AktaError.NotFound);

        var karyawan = await _karyawanRepository.GetByIdAsync(request.KaryawanId, cancellationToken);
        if (karyawan is null)
            return Result.Failure<Guid>(KaryawanError.NotFound);

        var trackingAkta = Domain.TrackingsAkta.TrackingAkta.CreateAkta(
            akta.Id,
            request.KaryawanId,
            request.DeskripsiAkta,
            DateTime.Now
        );
        _trackingAktaRepository.Add(trackingAkta);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(trackingAkta.Id);
    }
}
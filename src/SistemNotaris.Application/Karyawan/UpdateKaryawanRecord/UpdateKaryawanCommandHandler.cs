using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.UpdateKaryawanRecord;

internal sealed class UpdateKaryawanCommandHandler : ICommandHandler<UpdateKaryawanCommand>  
{
    private readonly IKaryawanRepository _karyawanRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateKaryawanCommandHandler(
        IKaryawanRepository karyawanRepository,
        IUnitOfWork unitOfWork)
    {
        _karyawanRepository = karyawanRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateKaryawanCommand request, CancellationToken cancellationToken)  {
        var karyawan = await _karyawanRepository.GetByIdAsync(request.Id, cancellationToken);
        if (karyawan == null)
        {
            return Result.Failure(KaryawanError.NotFound);
        }

        var result = karyawan.IncrementRecord();
        if (result.IsFailure)
        {
            return result;
        }
        _karyawanRepository.Update(karyawan);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
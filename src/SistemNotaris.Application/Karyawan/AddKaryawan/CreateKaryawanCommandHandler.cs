using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.AddKaryawan;

internal sealed class CreateKaryawanCommandHandler : ICommandHandler<CreateKaryawanCommand, Guid>
{
    private readonly IKaryawanRepository _karyawanRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateKaryawanCommandHandler(IKaryawanRepository karyawanRepository, IUnitOfWork unitOfWork)
    {
        _karyawanRepository = karyawanRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(CreateKaryawanCommand request, CancellationToken cancellationToken)
    {
        var karyawan = Karyawans.Create(request.Nama, request.NoTelfon);
        _karyawanRepository.Add(karyawan);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return karyawan.Id;
    }
}
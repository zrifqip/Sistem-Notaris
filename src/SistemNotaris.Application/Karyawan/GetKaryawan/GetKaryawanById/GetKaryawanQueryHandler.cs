using Dapper;
using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.GetKaryawan;

internal sealed class GetKaryawanQueryHandler : IQueryHandler<GetKaryawanQuery, KaryawanResponse>
{
    private readonly IKaryawanRepository _karyawanRepository;
    private readonly ISqlConnectionFactory _sqlconnectionFactory;

    public GetKaryawanQueryHandler(IKaryawanRepository karyawanRepository)
    {
        _karyawanRepository = karyawanRepository;
    }

    public async Task<Result<KaryawanResponse>> Handle(GetKaryawanQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlconnectionFactory.CreateConnection();
        var sql = "SELECT NAMA AS Nama FROM Karyawan WHERE IdKaryawan = @IdKaryawan";  
        var karyawan = await connection.QueryFirstOrDefaultAsync<KaryawanResponse>(
            sql,
            new { request.IdKaryawan });
        return karyawan;
    }
}
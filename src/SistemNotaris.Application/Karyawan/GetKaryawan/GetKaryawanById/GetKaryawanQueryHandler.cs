using Dapper;
using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Application.Karyawan.GetKaryawan.SearchKaryawan;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Karyawan;

namespace SistemNotaris.Application.Karyawan.GetKaryawan.GetKaryawanById;

internal sealed class GetKaryawanQueryHandler : IQueryHandler<GetKaryawanQuery, KaryawanResponse>
{
    private readonly ISqlConnectionFactory _sqlconnectionFactory;

    public GetKaryawanQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlconnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<KaryawanResponse>> Handle(GetKaryawanQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlconnectionFactory.CreateConnection();
        string sql = new Query().Value;
        sql += " WHERE Id = @IdKaryawan";  
        var karyawan = await connection.QueryFirstOrDefaultAsync<KaryawanResponse>(
            sql,
            new { request.IdKaryawan });
        return karyawan;
    }
}
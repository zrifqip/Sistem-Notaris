using Dapper;
using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Application.Karyawan.GetKaryawan.SearchKaryawan;

internal sealed class SearchKaryawanByNameQueryHandler : IQueryHandler<SearchKaryawanByNameQuery, KaryawanResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchKaryawanByNameQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<KaryawanResponse>> Handle(SearchKaryawanByNameQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        var parameters = new DynamicParameters();
        var sql = new Query().Value;;
        if (!string.IsNullOrEmpty(request.Name?.value))
        {
            sql += " WHERE NAMA LIKE @Name";
            parameters.Add("Name", $"%{request.Name}%");
        }
        sql += "ORDER BY NAMA";
        var karyawanList = await connection.QueryFirstOrDefaultAsync<KaryawanResponse>(sql, parameters);
        return karyawanList;
    }
}
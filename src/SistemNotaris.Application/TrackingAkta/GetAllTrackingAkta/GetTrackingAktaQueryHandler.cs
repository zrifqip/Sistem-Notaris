using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using Dapper;

namespace SistemNotaris.Application.TrackingAkta.GetAllTrackingAkta;

public class GetTrackingAktaQueryHandler : IQueryHandler<GetTrackingAktaQuery, TrackingResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTrackingAktaQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<TrackingResponse>> Handle(GetTrackingAktaQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                t.id AS Id,
                t.status AS Status,
                a.nama_akta AS AktaName,
                c.nama AS ClientName,
                k.nama AS KaryawanName,
            FROM tracking_akta t
            INNER JOIN akta a ON t.id_akta = a.id
            INNER JOIN client c ON a.id_client = c.id
            INNER JOIN Karyawan k ON t.id_karyawan = k.id
            WHERE t.status = @Status
        """;
        var parameters = new DynamicParameters();
        parameters.Add("Status", request.Status);
        if (!string.IsNullOrEmpty(request.ClientName))
        {
            sql += " AND c.nama LIKE @ClientName";
            parameters.Add("ClientName", $"%{request.ClientName}%");
        }
        if (!string.IsNullOrEmpty(request.AktaName))
        {
            sql += " AND a.nama_akta LIKE @AktaName";
            parameters.Add("AktaName", $"%{request.AktaName}%");
        }
        sql += $" ORDER BY t.created_at {(request.SortByDate.ToUpper() == "DESC" ? "DESC" : "ASC")}";
        var trackings = await connection.QueryAsync<TrackingResponse>(sql, parameters);
        return trackings.FirstOrDefault();
    }
}
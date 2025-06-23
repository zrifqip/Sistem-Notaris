using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using Dapper;

namespace SistemNotaris.Application.TrackingAkta.GetAllTrackingAkta;

internal sealed class GetTrackingAktaQueryHandler : IQueryHandler<GetTrackingAktaQuery, TrackingResponse>
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
                t.ID AS Id,
                t.STATUS AS Status,
                a.JENIS_AKTA AS JenisAkta,
                a.NAMA_AKTA AS NamaAkta,
                c.NAMA AS NamaClient,
                k.NAMA AS NamaKaryawan,
                t.DESKRIPSI AS Deskripsi,
                t.UPDATED_AT AS UpdatedAt
            FROM tracking_akta t
                INNER JOIN akta a ON t.id_akta = a.id
                INNER JOIN client c ON a.client_id = c.nik
                INNER JOIN karyawan k ON t.id_karyawan = k.id
        """;

        var parameters = new DynamicParameters();
        if(request.Status != null)
        {
            sql += " WHERE t.status = @Status";
            parameters.Add("Status", request.Status.ToString());
        }
        if (!string.IsNullOrEmpty(request.ClientName))
        {
            sql += " AND c.nama LIKE @ClientName";
            parameters.Add("ClientName", $"%{request.ClientName}%");
        }
        if (!string.IsNullOrEmpty(request.AktaName))
        {
            sql += " AND a.NAMA_AKTA LIKE @AktaName";
            parameters.Add("AktaName", $"%{request.AktaName}%");
        }
        sql += $" ORDER BY t.UPDATED_AT {(request.SortByDate.ToUpper() == "DESC" ? "DESC" : "ASC")}";
        var trackings = await connection.QueryAsync<TrackingResponse>(sql, parameters);
        return trackings.FirstOrDefault();
    }
}
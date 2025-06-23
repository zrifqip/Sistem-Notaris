using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.UpdateAkta;
using Dapper;

namespace SistemNotaris.Application.UpdateTrackingAkta.GetUpdateTracking;

public class GetUpdateTrackingQueryHandler : IQueryHandler<GetUpdateTrackingQuery, UpdateTrackingResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUpdateTrackingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<UpdateTrackingResponse>> Handle(GetUpdateTrackingQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
    
        const string sql = """
                               SELECT 
                                   k.nama AS NamaKaryawan,
                                   u.deskripsi_pengerjaan AS DeskripsiPengerjaan,
                                   u.created_at AS CreatedAt
                               FROM update_tracking_akta u
                               INNER JOIN karyawan k ON u.karyawan_id = k.id
                               WHERE u.tracking_id = @TrackingId 
                               ORDER BY u.created_at ASC 
                           """;
        var updateTracking = await connection.QueryFirstOrDefaultAsync<UpdateTrackingResponse>(
            sql,
            new
            { 
                request.TrackingId
            }
            );
        return updateTracking;
    }
}
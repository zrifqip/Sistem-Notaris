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
                                   id AS Id,
                                   tracking_id AS TrackingId,
                                   id_karyawan AS IdKaryawan,
                                   deskripsi_pengerjaan AS DeskripsiPengerjaan,
                                   created_at AS CreatedAt
                               FROM update_tracking_akta
                               WHERE tracking_id = @TrackingId
                               ORDER BY created_at ASC 
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
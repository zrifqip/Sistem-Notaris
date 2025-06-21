namespace SistemNotaris.Application.UpdateTrackingAkta.GetUpdateTracking;

public class UpdateTrackingResponse
{
    public required Guid Id { get; init; }
    public required Guid TrackingId { get; init; }
    public required Guid IdKaryawan { get; init; }
    public required string DeskripsiPengerjaan { get; init; }
    public required DateTime CreatedAt { get; init; }
}
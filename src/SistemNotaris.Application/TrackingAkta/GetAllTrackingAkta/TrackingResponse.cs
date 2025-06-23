using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.GetAllTrackingAkta;

internal sealed class TrackingResponse
{
    public Guid Id { get; set; }
    public string NamaClient { get; set; } = string.Empty;
    public string NamaKaryawan { get; set; } = string.Empty;
    public string JenisAkta { get; set; } = string.Empty;
    public string NamaAkta { get; set; } = string.Empty;
    public ProgresStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
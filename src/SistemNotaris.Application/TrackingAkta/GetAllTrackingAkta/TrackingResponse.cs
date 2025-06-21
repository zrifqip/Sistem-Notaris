using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.GetAllTrackingAkta;

public class TrackingResponse
{
    public Guid Id { get; set; }
    public string AktaName { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public ProgresStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<TrackingResponse>  Tracking { get; set; } = new();
}
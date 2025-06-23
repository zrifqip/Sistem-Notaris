using SistemNotaris.Application.Abstraction.Messaging;
using SistemNotaris.Domain.TrackingsAkta;

namespace SistemNotaris.Application.TrackingAkta.GetAllTrackingAkta;

public sealed record GetTrackingAktaQuery(
    ProgresStatus? Status = null,
    string? ClientName = null,
    string? AktaName = null,
    string SortByDate = "ASC"
    ) : IQuery<TrackingResponse>;

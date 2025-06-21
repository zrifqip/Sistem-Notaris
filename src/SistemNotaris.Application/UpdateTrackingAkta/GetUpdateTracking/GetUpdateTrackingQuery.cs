
using SistemNotaris.Application.Abstraction.Messaging;

namespace SistemNotaris.Application.UpdateTrackingAkta.GetUpdateTracking;

public record GetUpdateTrackingQuery(Guid TrackingId): IQuery<UpdateTrackingResponse>;
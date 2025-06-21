using SistemNotaris.Application.Abstraction.Messaging;

namespace SistemNotaris.Application.TrackingAkta.CancelAkta;

public record CancelAktaCommand(Guid TrackingId) : ICommand<Guid>;
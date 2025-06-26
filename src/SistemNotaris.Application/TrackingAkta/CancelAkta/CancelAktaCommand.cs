using SistemNotaris.Application.Abstraction.Messaging;

namespace SistemNotaris.Application.TrackingAkta.CancelAkta;

public sealed record CancelAktaCommand(Guid TrackingId) : ICommand<Guid>;
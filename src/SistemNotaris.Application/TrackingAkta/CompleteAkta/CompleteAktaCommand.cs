using SistemNotaris.Application.Abstraction.Messaging;

namespace SistemNotaris.Application.TrackingAkta.CompleteAkta;

public record CompleteAktaCommand(Guid TrackingAktaId) : ICommand;
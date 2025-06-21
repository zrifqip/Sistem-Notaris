using SistemNotaris.Application.Abstraction.Messaging;

namespace SistemNotaris.Application.Akta.DeleteAkta;

public record DeleteAktaCommand(Guid Id) : ICommand;

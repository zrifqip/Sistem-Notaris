using MediatR;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand : ICommand
{
}
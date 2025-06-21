using MediatR;
using SistemNotaris.Domain.Abstraction;

namespace SistemNotaris.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
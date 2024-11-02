using MediatR;

namespace Domain.Common;

public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : Command<TResponse>
{
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
using MediatR;

namespace Domain.Common;

public abstract class Command<TResponse> : IRequest<TResponse>, ICommandBase
{
    
}

public interface ICommandBase
{
    
}
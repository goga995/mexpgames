using Domain.Shared;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface ICommandHanlder<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{

}

public interface ICommandHanlder<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{

}
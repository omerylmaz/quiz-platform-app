using MediatR;
using Quiz.Domain.Abstractions;

namespace Quiz.Application.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;

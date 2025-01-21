using MediatR;
using Quiz.Domain.Abstractions;

namespace Quiz.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

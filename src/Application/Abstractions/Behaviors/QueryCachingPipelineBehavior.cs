using Application.Abstractions.Caching;
using MediatR;

namespace Application.Abstractions.Behaviors;

internal sealed class QueryCachingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
{
    private readonly ICacheService _cachedService;

    public QueryCachingPipelineBehavior(ICacheService cachedService)
    {
        _cachedService = cachedService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await _cachedService.GetOrCreatAsync(
            request.Key, _ => next(), request.Expiration, cancellationToken);
    }

}

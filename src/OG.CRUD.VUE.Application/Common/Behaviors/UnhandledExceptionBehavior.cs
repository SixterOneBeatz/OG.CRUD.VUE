using MediatR;
using Microsoft.Extensions.Logging;

namespace OG.CRUD.VUE.Application.Common.Behaviors
{
    internal class UnhandledExceptionBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Application Request: An exception occurred for the request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}

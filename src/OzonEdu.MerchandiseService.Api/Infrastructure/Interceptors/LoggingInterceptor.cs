using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Api.Infrastructure.Interceptors
{
    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation(requestJson);
            
            var response = base.UnaryServerHandler(request, context, continuation);

            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation(responseJson);
            
            return response;
        }

        public override TResponse BlockingUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context,
            BlockingUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation(requestJson);

            var response = base.BlockingUnaryCall(request, context, continuation);

            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation(responseJson);

            return response;
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation(requestJson);

            var response = base.AsyncUnaryCall(request, context, continuation);

            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation(responseJson);

            return response;
        }
    }
}
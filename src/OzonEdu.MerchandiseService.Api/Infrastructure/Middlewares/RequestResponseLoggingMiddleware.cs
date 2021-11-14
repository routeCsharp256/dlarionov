using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Api.Infrastructure.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var isGrpc = string.Compare("application/grpc", context.Request.ContentType,
                StringComparison.OrdinalIgnoreCase) >= 0;

            if (isGrpc)
            {
                await _next(context);
            }
            else
            {
                _logger.LogInformation(await FormatRequest(context.Request));

                var originalBodyStream = context.Response.Body;

                await using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);
                _logger.LogInformation(await FormatResponse(context.Response));
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            if (!request.ContentLength.HasValue) return "{}";
            var body = request.Body;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            var result = new
            {
                headers = request.Headers,
                route = $"{request.Host}{request.Path}",
                body = bodyAsText
            };
            return JsonSerializer.Serialize(result);
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            string bodyContent = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            // Форматирование умирает
            //var result = new
            //{
            //    headers = response.Headers,
            //    body = bodyContent
            //};

            //JsonSerializerOptions options = new JsonSerializerOptions
            //{
            //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //    WriteIndented = true
            //};

            return bodyContent;
        }
    }
}

using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddlewareDemo.Middleware
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            var elapsedMs = stopwatch.ElapsedMilliseconds;

            context.Items["RequestTime"] = elapsedMs;

            _logger.LogInformation("Запрос выполнен за {ElapsedMilliseconds} мс", elapsedMs);

            if (elapsedMs > 500)
            {
                _logger.LogWarning("⚠️ Предупреждение: запрос выполнялся слишком долго!: {ElapsedMilliseconds} мс", elapsedMs);
            }
        }

    }
}

using Serilog;
using Serilog.Core;
namespace PostDemo.Api.Middleware {
    public class RequestHeadersLoggingMiddleware {
        private readonly RequestDelegate _next;

        public RequestHeadersLoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            LogHeaders(context.Request.Headers); // логирование заголовков запроса

            await _next(context);
            Log.Information("Endpoint returned response");
        }

        private void LogHeaders(IHeaderDictionary headers) {
            Log.Information("Request header:");
                Log.Information("Host: {HeaderValue}",headers["Host"]);
            

        }
    }
}

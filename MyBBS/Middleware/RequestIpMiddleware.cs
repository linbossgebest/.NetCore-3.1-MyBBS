using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MyBBS.Middleware
{
    public class RequestIpMiddleware
    {
        public readonly RequestDelegate _next;
        private readonly ILog _logger;

        public RequestIpMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = LogManager.GetLogger(typeof(RequestIpMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.ToString();
            if (!(url.Contains("/css") || url.Contains("/js") || url.Contains("/images") || url.Contains("/lib")))
            {
                _logger.Info($"Url:{url} Ip:{context.Connection.RemoteIpAddress} DateTime:{DateTime.Now}");
            }
            await _next(context);
        }
    }

    public static class RequestIpMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestIp(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestIpMiddleware>();
        }
    }
}

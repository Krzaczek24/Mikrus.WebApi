using Krzaq.Exceptions.Http.Base;
using Krzaq.Exceptions.Http.Error.Base;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using NLog;
using System.Text;
using System.Text.Json;

namespace Krzaq.Mikrus.WebApi.Core.Middlewares
{
    public class LoggingMiddleware(RequestDelegate next)
    {
        protected static NLog.ILogger Logger { get; } = LogManager.GetLogger(nameof(LoggingMiddleware));

        public async Task Invoke(HttpContext httpContext)
        {
            await HandleRequest(httpContext);
            await HandleResponse(httpContext);
        }

        protected virtual async Task HandleRequest(HttpContext httpContext)
        {
            httpContext.PassRequestId();
            string bodyText = string.Empty;
            httpContext.Request.EnableBuffering();
            using (StreamReader reader = new (httpContext.Request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 1024, leaveOpen: true))
            {
                bodyText = await reader.ReadToEndAsync();
                httpContext.Request.Body.Position = 0L;
            }

            LogRequest(httpContext, bodyText);
        }

        protected virtual async Task HandleResponse(HttpContext httpContext)
        {
            var originalBodyStream = httpContext.Response.Body;
            var responseBody = new MemoryStream();
            httpContext.Response.Body = responseBody;
            try
            {
                await next(httpContext);
            }
            catch (HttpException ex)
            {
                httpContext.Response.StatusCode = (int)ex.StatusCode;
                await HandleException(httpContext, ex);
            }
            catch (System.Exception exception)
            {
                httpContext.Response.StatusCode = 500;
                await HandleException(httpContext, exception);
            }

            httpContext.Response.Body.Seek(0L, SeekOrigin.Begin);
            string bodyText = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
            httpContext.Response.Body.Seek(0L, SeekOrigin.Begin);
            LogResponse(httpContext, bodyText);
            await responseBody.CopyToAsync(originalBodyStream);
        }

        protected virtual async Task HandleException(HttpContext httpContext, System.Exception exception)
        {
            LogException(httpContext, exception);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(GetErrorResponse(exception)));
        }

        protected virtual void LogRequest(HttpContext httpContext, string bodyText)
        {
            Logger.Info($"REQUEST  ({httpContext.GetRequestId()}) | PATH ({httpContext.Request.GetPath()}) | BODY ({bodyText})");
        }

        protected virtual void LogResponse(HttpContext httpContext, string bodyText)
        {
            Logger.Info($"RESPONSE ({httpContext.GetRequestId()}) | CODE ({httpContext.Response.StatusCode}) | BODY ({bodyText})");
        }

        protected virtual void LogException(HttpContext httpContext, System.Exception exception)
        {
            if (httpContext.Response.StatusCode >= 500)
            {
                Logger.Error(exception, exception.Message);
            }
        }

        protected virtual object GetErrorResponse(System.Exception exception)
        {
            if (exception is HttpErrorException<ErrorModel> ex)
                return new ErrorResponse(ex.Errors);

            return new ErrorResponse(new ErrorModel()
            {
                Code = ErrorCode.Unknown,
                Message = exception.Message
            });
        }
    }

    public static class MiddlewareHelper
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app) => app.UseMiddleware<LoggingMiddleware>();
    }
}

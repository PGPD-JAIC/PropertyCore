using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PropertyCore.Application.Common.Exceptions;
using System.Net;
using System.Threading.Tasks;
using System;

namespace PropertyCore.WebUI.Common
{
    /// <summary>
    /// Class that creates custom exception handling
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Creates a new instance of the class
        /// </summary>
        /// <param name="next">A <see cref="RequestDelegate"/></param>
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// Invokes the middleware
        /// </summary>
        /// <param name="context">A <see cref="HttpContext"/></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        /// <summary>
        /// Handles Exceptions
        /// </summary>
        /// <param name="context">A <see cref="HttpContext"/></param>
        /// <param name="exception">A <see cref="Exception"/></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case BadRequestException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
    /// <summary>
    /// Class that contains exception extensions.
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

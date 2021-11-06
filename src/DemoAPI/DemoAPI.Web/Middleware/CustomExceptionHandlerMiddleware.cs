using DemoAPI.BLL.Common.Exceptions;
using DemoAPI.BLL.Services.Logging.LogException;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.Web.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, mediator);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex, IMediator mediator)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (ex)
            {
                case BadRequestEx bre:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(bre.Response);
                    break;
                default:
                    //ThreadPool.QueueUserWorkItem<IMediator>(mediator =>
                    //{ }, mediator, false);
                      mediator.Send(LogExceptionCmd.FromException(ex)).Wait();                   

                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
                result = JsonConvert.SerializeObject(new { error = ex.Message });

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dimng.Service.Helpers;
using Ding.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DingAPI.Middlewares
{
 
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpException exp)
            {
                await HandleExceptionAsync(httpContext, exp);
            }
            catch (Exception exp)
            {
                await HandleExceptionAsync(httpContext, exp);
            }

        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            if (ex is CustomHttpException)
            {
                CustomHttpException se = ex as CustomHttpException;
                statusCode = se.GetHttpCode();
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = new CustomExceptionResponseDto { Message = ex.Message, MessageCode = statusCode };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }

}

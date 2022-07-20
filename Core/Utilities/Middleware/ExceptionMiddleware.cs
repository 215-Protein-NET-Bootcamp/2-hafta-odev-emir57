using Core.Utilities.Result;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Core.Utilities.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception e)
            {
                await HandleAsync(context, e);
            }
        }

        private async Task HandleAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal server error";

            if (e.GetType() == typeof(ValidationException))
            {
                getErrorMessages(e, out message);
            }
            var json = JsonConvert.SerializeObject(new ErrorResult(message), Formatting.Indented);
            await context.Response.WriteAsync(json);
        }

        private void getErrorMessages(Exception e, out string message)
        {
            var errors = ((ValidationException)e).Errors;
            message = string.Join("\n", errors.Select(x => x.ErrorMessage));
        }
    }
}

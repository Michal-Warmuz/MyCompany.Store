using MyCompany.Store.Application.Shared.Exceptions;
using MyCompany.Store.Core.Domain.SeedWork;
using Newtonsoft.Json;
using System.Net;

namespace MyCompany.Store.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var message = string.Empty;

                switch (error)
                {
                    case InvalidCommandException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        message = string.Join(',', e.Errors);
                        break;
                    case BusinessRuleValidationException e:
                        response.StatusCode = StatusCodes.Status409Conflict;
                        message = e.Message;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        message = error.Message;
                        break;
                }

                var result = JsonConvert.SerializeObject(new { message = message });
                await response.WriteAsync(result);
            }
        }
    }
}

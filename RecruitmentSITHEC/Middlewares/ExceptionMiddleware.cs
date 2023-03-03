using RecruitmentSITHEC.Helpers.Errors;
using System.Net;
using System.Text.Json;

namespace RecruitmentSITHEC.Middlewares
{
    /// <summary>
    /// Middleware to handle exceptions in the application
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            _logger = logger;
            _env = env;
        }

        //HTTP Info
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);  //next middleware - not exception found
            }
            catch (Exception ex)
            {
                // have exception

                var statusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var response = _env.IsDevelopment()
                                ? new ExceptionAPI(statusCode, ex.Message, ex.StackTrace.ToString())
                                : new ExceptionAPI(statusCode);

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}

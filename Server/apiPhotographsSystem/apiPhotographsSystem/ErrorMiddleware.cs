using System.Net;


namespace apiPhotographsSystem
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger<ErrorMiddleware> _logger;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<ErrorMiddleware> logger)
        {
            _logger = logger;
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error From My Middleare: " + ex.Message + "Stack Tracre is: " + ex.StackTrace);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}

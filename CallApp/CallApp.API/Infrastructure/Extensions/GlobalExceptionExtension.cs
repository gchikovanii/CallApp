using CallApp.API.Infrastructure.Middlewares;

namespace CallApp.API.Infrastructure.Extensions
{
    public static class GlobalExceptionExtension
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}

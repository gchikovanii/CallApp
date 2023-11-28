using CallApp.API.Infrastructure.Middlewares;

namespace CallApp.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureConfigurationMiddleware>();
        }
    }
}

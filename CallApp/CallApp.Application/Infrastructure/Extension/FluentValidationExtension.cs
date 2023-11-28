using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CallApp.Application.Infrastructure.Extension
{
    public static class FluentValidationExtension
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        }
    }
}

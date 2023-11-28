using CallApp.Infrastructure.Repositories.Abstraction;
using CallApp.Infrastructure.Repositories.Implementation;
using CallApp.Infrastructure.Units;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallApp.Application.Infrastructure.Extension
{
    public static class ServiceInjectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

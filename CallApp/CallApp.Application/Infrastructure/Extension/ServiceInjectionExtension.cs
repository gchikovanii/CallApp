using CallApp.Infrastructure.Repositories.BaseRepo.Abstraction;
using CallApp.Infrastructure.Repositories.BaseRepo.Implementation;
using CallApp.Infrastructure.Repositories.UserRepo;
using CallApp.Infrastructure.Units;
using Microsoft.Extensions.DependencyInjection;

namespace CallApp.Application.Infrastructure.Extension
{
    public static class ServiceInjectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

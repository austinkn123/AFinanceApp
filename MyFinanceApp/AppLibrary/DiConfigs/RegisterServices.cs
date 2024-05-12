using AppLibrary.IRepositories;
using AppLibrary.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppLibrary.DiConfigs
{
    public class RegisterServices
    {
        public static void AddServicesToRepositories(IServiceCollection services)
        {
            // Register repositories
            services.AddTransient<IUserRepository, UserRepository>();
            // Add more repositories here if needed
        }
    }
}

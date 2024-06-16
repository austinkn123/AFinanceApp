using FluentValidation;
using System.Reflection;

namespace MyFinanceApp.Server.Site
{
    public class DiConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, Settings settings)
        {
            AppLibrary.DiConfiguration.ConfigureServices(services, settings);
            services.AddSingleton(settings);
            var assembly = typeof(DiConfiguration).GetTypeInfo().Assembly;
            services.RegisterServices(assembly, settings);
        }
    }
}

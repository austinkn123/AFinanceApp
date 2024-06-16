using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentValidation;

namespace AppLibrary
{
    public class DiConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, Settings settings)
        {
            if (services.Any(sd => sd.ServiceType == typeof(Settings))) return;
            services.AddHttpClient();
            services.AddSingleton(settings);
            var assembly = typeof(DiConfiguration).GetTypeInfo().Assembly;
            services.AddValidatorsFromAssembly(assembly);
            services.RegisterServices(assembly, settings);
        }
    }
}

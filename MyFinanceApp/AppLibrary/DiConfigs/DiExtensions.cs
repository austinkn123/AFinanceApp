using App.Utils;
using AppLibrary;
using AppLibrary.DiConfigs;
using Dapper;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {


        public static void RegisterServices(this IServiceCollection services, Assembly assembly, Settings settings)
        {
            var sqlServerFactory = typeof(DbAdapterFactory).GetMethod(nameof(DbAdapterFactory.GetConnectionAs));

            foreach (var type in assembly.GetExportedTypes())
            {
                if (type.GetCustomAttribute<TransientServiceAttribute>() != null)
                {
                    services.AddTransient(type);
                }
                else if (type.GetCustomAttribute<SingletonServiceAttribute>() != null)
                {
                    services.AddSingleton(type);
                }
                else if (type.GetCustomAttribute<ScopedServiceAttribute>() != null)
                {
                    services.AddScoped(type);
                }
                else if (type.GetCustomAttribute<DatabaseServiceAttribute>(true) is DatabaseServiceAttribute databaseServiceAttribute)
                {
                    services.AddTransient(type, (serviceProvider) =>
                    {

                        var connectionString = settings.DatabaseConnectionStrings[databaseServiceAttribute.ConnectionStringName];

                        var genericMethod = sqlServerFactory.MakeGenericMethod(type);
                        return genericMethod.Invoke(null, new object[] { connectionString });
                    });
                }
            }
        }
    }
}
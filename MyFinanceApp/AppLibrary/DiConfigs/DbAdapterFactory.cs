using Insight.Database;
using Npgsql;

namespace App.Utils
{
    public static class DbAdapterFactory
    {
        /// <summary>
        /// Creates and returns an instance of a type T that is configured with the provided connection string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static T GetConnectionAs<T>(string connectionString) where T : class
        {
            return new NpgsqlConnectionStringBuilder(connectionString).As<T>();
        }

        /// <summary>
        /// Registers the PostgreSQL provider with the Insight.Database library
        /// </summary>
        /// This constructor is called automatically when the DbAdapterFactory class is first accessed, 
        /// ensuring that the PostgreSQL provider is registered early in the application’s lifecycle
        static DbAdapterFactory()
        {
            Insight.Database.Providers.PostgreSQL.PostgreSQLInsightDbProvider.RegisterProvider();
        }
    }
}
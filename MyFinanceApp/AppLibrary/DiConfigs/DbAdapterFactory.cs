using Insight.Database;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace App.Utils
{
    public static class DbAdapterFactory
    {
        public static T GetConnectionAs<T>(string connectionString) where T : class
        {
            return new NpgsqlConnectionStringBuilder(connectionString).As<T>();
        }

        static DbAdapterFactory()
        {
            Insight.Database.Providers.PostgreSQL.PostgreSQLInsightDbProvider.RegisterProvider();
        }
    }
}
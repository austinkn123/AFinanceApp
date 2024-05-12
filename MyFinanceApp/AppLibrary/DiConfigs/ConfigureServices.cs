using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace AppLibrary.DiConfigs
{
    public class ConfigureServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ConfigureServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("FinanceConnection");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}

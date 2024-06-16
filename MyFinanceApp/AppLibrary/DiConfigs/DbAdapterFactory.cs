using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.DiConfigs
{
    public class DbAdapterFactory
    {
        public static class DapperFactory
        {
            public static NpgsqlConnection GetConnection(string connectionString)
            {
                return new NpgsqlConnection(connectionString);
            }
        }

    }
}

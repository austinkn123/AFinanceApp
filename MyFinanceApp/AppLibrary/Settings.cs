using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class Settings
    {
        public Settings(IConfiguration configuration) 
        {
            DatabaseConnectionStrings = new Dictionary<string, string> 
            {
                {ConnectionStrings.Finance, configuration.GetConnectionString(ConnectionStrings.Finance)}
            };

            configuration.SetProps(this, nameof(DatabaseConnectionStrings));
        }

        public Dictionary<string, string> DatabaseConnectionStrings { get; private set; }
    }
}

﻿using ConnectionStrings;
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
        /// <summary>
        /// Provides a way to centralize and manage configuration settings, specifically connection strings in this case
        /// </summary>
        /// <param name="configuration"></param>
        /// IConfiguration Parameter: Represents the configuration source (such as appsettings.json or environment variables).
        /// Configuration.GetConnectionString(ConnectionStrings.Finance) retrieves a connection string named Finance from the configuration source.
        public Settings(IConfiguration configuration) 
        {
            //Stores connection strings in a dictionary.
            //The dictionary is initialized in the constructor with a specific connection string and can be accessed as needed.
            DatabaseConnectionStrings = new Dictionary<string, string> 
            {
                {ConnectionString.Finance, configuration.GetConnectionString(ConnectionString.Finance)}
            };
            //Applies additional configuration settings to the Settings object
            //nameof = takes the dictionary and changes it to a string on compilation
            configuration.SetProps(this, nameof(DatabaseConnectionStrings));
        }

        public Dictionary<string, string> DatabaseConnectionStrings { get; private set; }
    }
}

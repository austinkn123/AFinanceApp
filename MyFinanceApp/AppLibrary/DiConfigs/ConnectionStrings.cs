using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
    //an attribute applied to the DatabaseServiceAttribute class. It specifies that DatabaseServiceAttribute can only be applied to classes.
    //AttributeUsage is a predefined attribute that controls how the custom attribute can be used.
    //now an adapter class can be decorated with a database connection attribute
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DatabaseServiceAttribute : Attribute
    {
        public DatabaseServiceAttribute(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
        }

        public string ConnectionStringName { get;}

    }
    public sealed class ConnectionStrings
    {
        public const string Finance = "FinanceConnection";
    }
}

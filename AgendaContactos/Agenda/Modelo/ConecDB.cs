using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public static class ConecDB
    {
        private const string Server = "localhost\\SQLEXPRESS";
        private const string DBName = "AGENDA_DB";
        public static string GetConnectionString()
        {
            return string.Concat(
                "Data Source=",
                Server,
                ";",
                "Initial Catalog=",
                DBName,
                ";Integrated Security=true;"
            );
        }

    }
}

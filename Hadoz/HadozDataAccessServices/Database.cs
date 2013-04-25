using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;


namespace HadozDataAccessServices
{
    public static class Database
    {
        public static string HadozDB()
        {
            return ConfigurationManager.ConnectionStrings["HadozDB"].ConnectionString;
        }
    }
}

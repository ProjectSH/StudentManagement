using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace StudentManagement.DapperRepository
{
    public static class SqlHelper
    {

        public static string GetSqlConnection()
        {
            return ConfigurationManager.ConnectionStrings["DapperContext"].ConnectionString;
        }
    }
}

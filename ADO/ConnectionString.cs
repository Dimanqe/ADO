using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data;
namespace ADO
{

    public static class ConnectionString
    {
        public static string MsSqlConnection => @"Data Source=.\SQLEXPRESS01;Database=testing;Trusted_Connection=True;Trust Server Certificate=True";

    }


}

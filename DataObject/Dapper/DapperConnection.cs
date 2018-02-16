using System.Data;
using System.Data.SqlClient;

namespace DataObject.Dapper
{
    public class DapperConnection
    {
        //Warning : This will fail in multi threading environment as this is a static connection
        //but to just save some typing i did it like this
        public static IDbConnection TestProj => new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
    }
}



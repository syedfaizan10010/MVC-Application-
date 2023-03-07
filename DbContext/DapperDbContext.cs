using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace formProject.DbContext
{
    public class DapperDbContext
    {
        private string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FormsDb;Integrated Security=True";
        public IDbConnection GetConnection()
        {

            return new SqlConnection(ConnectionString);
        }
    }
}

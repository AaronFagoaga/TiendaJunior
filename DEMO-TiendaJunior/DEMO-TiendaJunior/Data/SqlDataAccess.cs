using Microsoft.Data.SqlClient;
using System.Data;

namespace DEMO_TiendaJunior.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }

        public IDbConnection GetConnection() => new SqlConnection(_connectionString);
    }
}

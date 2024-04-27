using System.Data;

namespace DEMO_TiendaJunior.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}

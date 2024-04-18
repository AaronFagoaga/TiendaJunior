using Dapper;
using System.Data;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.Venta
{
    public class VentasRepository : IVentaRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public VentasRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<VentasModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spVentas_GetAll";

                return connection.Query<VentasModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public VentasModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spVentas_GetById";

                return connection.QueryFirstOrDefault<VentasModel>(
                                    storeProcedure,
                                    new { Id_Venta = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(VentasModel ventas)
        {
            using(var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spVentas_Insert";

                connection.Execute(
                    storeProcedure,
                    new { ventas.dFecha, ventas.Cliente, ventas.Encargado },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(VentasModel ventas)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spVentas_Update";

                connection.Execute(
                    storeProcedure,
                    new { ventas.Id_Venta, ventas.dFecha, ventas.Cliente, ventas.Encargado },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spVentas_Delete";

                connection.Execute(
                    storeProcedure,
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        
    }
}

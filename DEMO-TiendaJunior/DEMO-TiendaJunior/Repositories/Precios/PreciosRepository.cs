using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.Precios
{
    public class PreciosRepository : IPreciosRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        public PreciosRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Add(PrecioModel precio)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spPrecio_Insert";

                connection.Execute(
                    storeProcedure,
                    new { precio.Id_Producto, precio.PrecioUnidad },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spPrecio_Delete";

                connection.Execute(
                    storeProcedure,
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(PrecioModel precio)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spPrecio_Update";

                connection.Execute(storeProcedure, precio, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<PrecioModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spPrecio_GetAll";
                var productos = connection.Query<PrecioModel, ProductoModel, PrecioModel>
                     (storedProcedure, (precio, producto) =>
                     {
                         precio.Producto = producto;

                         return precio;
                     },
                     splitOn: "Nombre_Producto",
                     commandType: CommandType.StoredProcedure);

                return productos;
            }
        }

        public IEnumerable<ProductoModel> GetAllProductos()
        {
            string query = "SELECT Id_Producto, Nombre_Producto FROM TBL_Producto;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<ProductoModel>(query);
            }
        }

        public PrecioModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spPrecio_GetById";

                return connection.QueryFirstOrDefault<PrecioModel>(
                                    storeProcedure,
                                    new { Id_Precio = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }
    }
}
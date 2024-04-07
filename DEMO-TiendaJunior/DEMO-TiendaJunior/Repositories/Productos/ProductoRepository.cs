using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.Productos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ProductoRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<CategoriaModel> GetAllCategorias()
        {
            string query = "SELECT Id_categoria, Nombre FROM Tbl_Categoria;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<CategoriaModel>(query);
            }
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducto_GetAll";

                var productos = connection.Query<ProductoModel, CategoriaModel, ProductoModel>
                    (storedProcedure, (producto, categoria) =>
                    {
                        producto.Categoria = categoria;

                        return producto;
                    },
                    splitOn: "Nombre",
                    commandType: CommandType.StoredProcedure);

                return productos;
            }
        }

        public ProductoModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducto_GetById";

                return connection.QueryFirstOrDefault<ProductoModel>(
                                           storedProcedure,
                                           new { Id_Producto = id },
                                           commandType: CommandType.StoredProcedure
                                          );

            }
        }

        public void Add(ProductoModel productos)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spProducto_Insert";

                connection.Execute(
                    storedProcedure,
                    new { productos.Nombre_Producto, productos.Presentacion, productos.Stock, productos.Id_categoria },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(ProductoModel productos)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spProducto_Update ";

                connection.Execute(storedprocedure, productos, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spProducto_Delete";

                connection.Execute(
                    storedprocedure,
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

    }
}

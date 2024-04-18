using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.DetallesVentas
{
	public class DetalleRepository : IDetalleRepository
	{
		private readonly ISqlDataAccess _dataAccess;

		public DetalleRepository(ISqlDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public void Add(DetalleModel detalle)
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storeProcedure = "dbo.spDetalleVenta_Insert";

				connection.Execute(
					storeProcedure,
					new { detalle.Cantidad, detalle.Id_Venta, detalle.Id_Producto },
					commandType: CommandType.StoredProcedure
					);
			}
		}

		public void Delete(int id)
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storeProcedure = "dbo.spDetalleVenta_Delete";

				connection.Execute(
					storeProcedure,
					new { id },
					commandType: CommandType.StoredProcedure
					);
			}
		}

		public void Edit(DetalleModel detalle)
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storeProcedure = "dbo.spDetalleVenta_Update";

                connection.Execute(
                    storeProcedure,
                    new { detalle.Id_Detalle, detalle.Cantidad, detalle.Id_Producto },
                    commandType: CommandType.StoredProcedure
                    );
            }
		}

		public IEnumerable<DetalleModel> GetAllByIdVenta(int Id_Venta)
		{
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDetalleVenta_GetByIdVenta";
                var productos = connection.Query<DetalleModel, ProductoModel, DetalleModel>
                     (storedProcedure, (detalle, producto) =>
                     {
                         detalle.Producto = producto;

                         return detalle;
                     },
                     new { Id_Venta }, // Pasa el parámetro Id_Venta al procedimiento almacenado
                     splitOn: "Nombre_Producto",
                     commandType: CommandType.StoredProcedure);

                return productos;
            }
        }

		public IEnumerable<PrecioModel> GetAllPrecios()
		{
			string query = "SELECT Id_Precio, PrecioUnidad, IdProducto FROM TBL_Precio;";

			using (var connection = _dataAccess.GetConnection())
			{
				return connection.Query<PrecioModel>(query);
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

		public DetalleModel? GetById(int id)
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storeProcedure = "dbo.spDetalleVenta_GetById";

				return connection.QueryFirstOrDefault<DetalleModel>(
									storeProcedure,
									new { Id_Detalle = id },
									commandType: CommandType.StoredProcedure
								   );
			}
		}
	}
}

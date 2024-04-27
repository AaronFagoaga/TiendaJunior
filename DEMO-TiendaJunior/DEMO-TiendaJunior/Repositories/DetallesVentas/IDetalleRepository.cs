using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.DetallesVentas
{
	public interface IDetalleRepository
	{
		void Add(DetalleModel detalle);
		void Delete(int id);
		void Edit(DetalleModel detalle);
		IEnumerable<DetalleModel> GetAllByIdVenta(int Id_Venta);
		IEnumerable<PrecioModel> GetAllPrecios();
		IEnumerable<ProductoModel> GetAllProductos();

		DetalleModel? GetById(int id);
	}
}

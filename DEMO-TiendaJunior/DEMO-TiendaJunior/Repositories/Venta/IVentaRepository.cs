using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.Venta
{
    public interface IVentaRepository
    {
        void Add(VentasModel ventas);
        void Delete(int id);
        void Edit(VentasModel ventas);
        IEnumerable<VentasModel> GetAll();
        VentasModel? GetById(int id);
    }
}

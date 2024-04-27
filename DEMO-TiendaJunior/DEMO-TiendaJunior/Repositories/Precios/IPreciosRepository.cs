using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.Precios
{
    public interface IPreciosRepository

    {
        void Add(PrecioModel precio);
        void Delete(int id);
        void Edit(PrecioModel precio);
        IEnumerable<PrecioModel> GetAll();
        IEnumerable<ProductoModel> GetAllProductos();

        PrecioModel? GetById(int id);
    }
}
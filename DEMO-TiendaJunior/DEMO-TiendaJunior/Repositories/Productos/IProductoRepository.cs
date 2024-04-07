using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.Productos
{
    public interface IProductoRepository
    {
        void Add(ProductoModel productos);
        void Delete(int id);
        void Edit(ProductoModel productos);
        IEnumerable<ProductoModel> GetAll();
        IEnumerable<CategoriaModel> GetAllCategorias();
        ProductoModel? GetById(int id);
    }
}

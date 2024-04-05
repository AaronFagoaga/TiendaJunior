using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.Categoria
{
    public interface ICategoriaRepository
    {
        void Add(CategoriaModel categoria);
        void Delete(int id);
        void Edit(CategoriaModel categoria);
        IEnumerable<CategoriaModel> GetAll();
        CategoriaModel? GetById(int id);
    }
}

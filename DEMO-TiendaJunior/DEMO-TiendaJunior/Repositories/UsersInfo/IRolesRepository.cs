using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.UsersInfo
{
    public interface IRolesRepository
    {
        IEnumerable<RolesModel> GetAll();
        RolesModel? GetById(int id);

        void Add(RolesModel rol);
        void Edit(RolesModel rol);
        void Delete(int id);
    }
}

using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.UsersInfo
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioModel> GetAll();
        IEnumerable<RolesModel> GetAllRoles();
        UsuarioModel? GetById(int id);

        void Add(UsuarioModel usuario);
        void Edit(UsuarioModel usuario);
        void Delete(int id);

    }
}

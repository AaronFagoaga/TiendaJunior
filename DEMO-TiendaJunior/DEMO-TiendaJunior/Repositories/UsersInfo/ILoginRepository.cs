using DEMO_TiendaJunior.Models;

namespace DEMO_TiendaJunior.Repositories.UsersInfo
{
    public interface ILoginRepository
    {
        void Add(LoginModel logins);
        void Delete(int id);
        void Edit(LoginModel logins);
        IEnumerable<LoginModel> GetAll();
        IEnumerable<UsuarioModel> GetAllUsuarios();
        LoginModel? GetById(int id);
    }
}

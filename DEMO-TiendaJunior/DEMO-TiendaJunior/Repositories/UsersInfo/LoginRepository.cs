using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.UsersInfo
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        public LoginRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<UsuarioModel> GetAllUsuarios()
        {
            string query = "SELECT Id_Usuario, Nombre FROM Tbl_Usuario;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<UsuarioModel>(query);
            }
        }

        public IEnumerable<LoginModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spLogin_GetAll";

                var logins = connection.Query<LoginModel, UsuarioModel, LoginModel>
                    (storedProcedure, (login, usuario) =>
                    {
                        login.Usuario = usuario;

                        return login;
                    },
                    splitOn: "Nombre",
                    commandType: CommandType.StoredProcedure);

                return logins;
            }
        }
        public LoginModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spLogin_GetById";

                return connection.QueryFirstOrDefault<LoginModel>(
                                           storedProcedure,
                                           new { Id_Login = id },
                                           commandType: CommandType.StoredProcedure
                                          );

            }
        }

        public void Add(LoginModel logins)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spLogin_Insert";

                connection.Execute(
                    storedProcedure,
                    new { logins.UserName, logins.Contraseña, logins.Id_Usuario},
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spLogin_Delete";

                connection.Execute(
                    storedprocedure,
                    new { Id_Login = id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(LoginModel logins)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spLogin_Update";

                connection.Execute(
                    storedprocedure,
                    new { logins.Id_Login, logins.UserName, logins.Contraseña, logins.Id_Usuario},
                    commandType: CommandType.StoredProcedure
                   );
            }
        }

        public IEnumerable<RolesModel> GetAllRoles()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spRoles_GetAll";
                return connection.Query<RolesModel>(storedprocedure,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public LoginModel? GetCredentials(string username, string Password)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spLogin_Credentials";

                return
                    connection.QueryFirstOrDefault<LoginModel>(
                    storedprocedure,
                    new { UserName = username, Contraseña = Password },
                    commandType: CommandType.StoredProcedure
                   );
            }
        }
    }
}

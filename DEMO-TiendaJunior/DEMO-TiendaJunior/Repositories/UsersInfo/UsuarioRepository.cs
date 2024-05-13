using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.UsersInfo
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        public UsuarioRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Add(UsuarioModel usuario)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUsuario_Insert";
                connection.Execute(
                storedProcedure,
                new { usuario.Nombre, usuario.Edad, usuario.Contacto, usuario.Id_Roles },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spUsuario_Delete";

                connection.Execute(
                    storedprocedure,
                    new { Id_Usuario = id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(UsuarioModel usuario)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spUsuario_Update";
                connection.Execute(
                storedprocedure,
                new { usuario.Id_Usuario, usuario.Nombre, usuario.Edad, usuario.Contacto, usuario.Id_Roles},
                commandType: CommandType.StoredProcedure
                );
            }
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUsuario_GetAll";

                var usuarios = connection.Query<UsuarioModel, RolesModel, UsuarioModel>
                    (storedProcedure, (usuario, rol) =>
                    {
                        usuario.Roles = rol;

                        return usuario;
                    },
                    splitOn: "Nombre",
                    commandType: CommandType.StoredProcedure);

                return usuarios;
            }
        }

        public IEnumerable<RolesModel> GetAllRoles()
        {
            string query = "SELECT Id_Roles, Nombre FROM Tbl_Roles;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<RolesModel>(query);
            }
        }

        public UsuarioModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUsuario_GetById";

                return connection.QueryFirstOrDefault<UsuarioModel>(
                                           storedProcedure,
                                           new { Id_Usuario = id },
                                           commandType: CommandType.StoredProcedure
                                          );

            }
        }
    }
}

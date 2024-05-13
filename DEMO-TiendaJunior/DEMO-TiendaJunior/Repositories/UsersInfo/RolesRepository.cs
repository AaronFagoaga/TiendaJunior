using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.UsersInfo
{
    public class RolesRepository : IRolesRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        public RolesRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Add(RolesModel rol)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spRoles_Insert";
                connection.Execute(
                storedProcedure,
                new { rol.Nombre, rol.Descripcion, rol.NivelPrivilegios},
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spRoles_Delete";

                connection.Execute(
                    storedprocedure,
                    new { Id_Roles = id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(RolesModel rol)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedprocedure = "dbo.spRoles_Update";
                connection.Execute(
                storedprocedure,
                new { rol.Id_Roles, rol.Nombre, rol.Descripcion, rol.NivelPrivilegios },
                commandType: CommandType.StoredProcedure
                );
            }
        }

        public IEnumerable<RolesModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoles_GetAll";

                return connection.Query<RolesModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public RolesModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spRoles_GetById";

                return connection.QueryFirstOrDefault<RolesModel>(
                                           storedProcedure,
                                           new { Id_Roles = id },
                                           commandType: CommandType.StoredProcedure
                                          );

            }
        }
    }
}

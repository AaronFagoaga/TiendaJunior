using Dapper;
using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Models;
using System.Data;

namespace DEMO_TiendaJunior.Repositories.Categoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public CategoriaRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<CategoriaModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCategoria_GetAll";

                return connection.Query<CategoriaModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public CategoriaModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCategoria_GetById";

                return connection.QueryFirstOrDefault<CategoriaModel>(
                                    storeProcedure,
                                    new { Id_Categoria = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(CategoriaModel categoria)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCategoria_Insert";

                connection.Execute(
                    storeProcedure,
                    new { categoria.Nombre, categoria.Descripcion },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(CategoriaModel categoria)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCategoria_Update";

                connection.Execute(storeProcedure, categoria, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spCategoria_Delete";

                connection.Execute(
                    storeProcedure,
                    new { Id_Categoria = id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
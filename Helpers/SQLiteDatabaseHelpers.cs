using SQLite;
using AplicativoAcademico.Models;

namespace AplicativoAcademico.Helpers
{
    public class SQLiteDatabaseHelpers
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelpers(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Periodo>().Wait();
        }

        public Task<int> Insert(Periodo p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Periodo>> Update(Periodo p)
        {
            string sql = "UPDATE Periodo SET Nome = ? WHERE Codigo = ?";
            return _connection.QueryAsync<Periodo>(sql, p.Nome, p.Codigo);
        }

        public Task<int> Delete(int p)
        {
            return _connection.Table<Periodo>().DeleteAsync(i => i.Codigo == p);

            /*
            É POSSÍVEL UTILIZAR DOIS MÉTODOS DE ACESSO AOS DADOS NA TABELA, O OUTRO PODE SER ATRAVÉS DA STRING:
            
            string sql = "DELETE FROM Periodo WHERE Codigo = ?";
            return _connection.QueryAsync<Periodo>(sql, p);
            */
        }

        public Task<List<Periodo>> GetAll()
        {
            return _connection.Table<Periodo>().ToListAsync();
        }

        public Task<List<Periodo>> Search(string p)
        {
            string sql = "SELECT * FROM Periodo WHERE Nome LIKE '%" + p + "%'";
            return _connection.QueryAsync<Periodo>(sql);
        }
    }
}

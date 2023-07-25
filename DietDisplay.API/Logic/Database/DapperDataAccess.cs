using Dapper;
using System.Data;

namespace DietDisplay.API.Logic.Database
{
    public class DapperDataAccess : IDataAccess
    {
        private readonly IDbConnection connection;

        public DapperDataAccess(IDbConnection connection)
        {
            this.connection = connection;
        }

        /// <inheritdoc/>
        public IEnumerable<T> Query<T>(string query, object? parameters = null)
            => connection.Query<T>(query, parameters);

        /// <inheritdoc/>
        public int Execute(string query, object? parameters = null)
            => connection.Execute(query, parameters);
    }
}

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
        public IEnumerable<T> Query<T>(IQuery query)
            => connection.Query<T>(query.Sql, query.Parameters);

        /// <inheritdoc/>
        public int Execute(IQuery query)
            => connection.Execute(query.Sql, query.Parameters);
    }
}

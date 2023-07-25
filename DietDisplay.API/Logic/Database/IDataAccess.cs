namespace DietDisplay.API.Logic.Database
{
    public interface IDataAccess
    {
        /// <summary>
        /// Executes a query, returning the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="query">The SQL to execute for the query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column is assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        IEnumerable<T> Query<T>(string query, object? parameters = null);

        /// <summary>
        /// Execute parametrized SQL.
        /// </summary>
        /// <param name="query">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <returns>Number of rows affected</returns>
        int Execute(string query, object? parameters = null);
    }
}

namespace DietDisplay.API.Logic.Database
{
    public interface IDataAccess
    {
        /// <summary>
        /// Executes a query, returning the data typed as <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="query">Object representing the query to call</param>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column is assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        IEnumerable<T> Query<T>(IQuery query);

        /// <summary>
        /// Execute parametrized SQL.
        /// </summary>
        /// <param name="query">Object representing the query to call</param>
        /// <returns>Number of rows affected</returns>
        int Execute(IQuery query);
    }
}

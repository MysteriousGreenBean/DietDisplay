namespace DietDisplay.API.Logic.Database
{
    /// <summary>
    /// Represents query called to the database.
    /// </summary>
    public interface IQuery
    {
        /// <summary>
        /// The SQL to execute for the query.
        /// </summary>
        string Sql { get; }
        /// <summary>
        /// The parameters to pass, if any.
        /// </summary>
        object? Parameters { get; }
    }
}

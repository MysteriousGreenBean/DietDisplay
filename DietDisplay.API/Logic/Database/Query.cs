namespace DietDisplay.API.Logic.Database
{
    public class Query : IQuery
    {
        /// <inheritdoc/>
        public required string Sql { get; init; }
        /// <inheritdoc/>
        public object? Parameters { get; init; }
    }
}

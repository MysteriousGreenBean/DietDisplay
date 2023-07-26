namespace DietDisplay.API.Logic.DateProvider
{
    public class DateProvider : IDateProvider
    {
        /// <inheritdoc/>
        public DateTime GetCurrentUtcDate() => DateTime.UtcNow.Date;
    }
}

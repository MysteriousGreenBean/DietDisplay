namespace DietDisplay.API.Logic.DateProvider
{
    public interface IDateProvider
    {
        /// <summary>
        /// Gets current UTC date - time is set to 00:00:00.
        /// </summary>
        /// <returns>Current UTC date with time set to 00:00:00.</returns>
        DateTime GetCurrentUtcDate();
    }
}

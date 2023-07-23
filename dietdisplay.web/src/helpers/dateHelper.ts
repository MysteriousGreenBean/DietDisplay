
/**
 * @remarks
 * This function is used to get the provided date - only date, time is set to 00:00.
 * @param date - Date to be based on
 * @returns New date with time set to 00:00
 */
export const getDate = (date: Date) => {
    const newDate = new Date(date);
    newDate.setHours(0, 0, 0, 0);
    return newDate;
};

/**
 * @remarks
 * This function is used to add days to the provided date.
 * @param date - Date to be based on
 * @param days - Number of days to be added
 * @returns New date with added days
 */
export const addDays = (days: number, date: Date = getCurrentDate()) => {
    const newDate = getDate(date);
    newDate.setDate(newDate.getDate() + days);
    return newDate;
};

/**
 * @remarks
 * This function is used to get current date - only date, time is set to 00:00.
 * @returns Current date with time set to 00:00
 */
export const getCurrentDate = () => {
    return getDate(new Date());
};
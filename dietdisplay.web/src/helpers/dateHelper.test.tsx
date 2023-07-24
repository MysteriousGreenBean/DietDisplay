import { addDays, getCurrentDate, getDate } from './dateHelper';

describe('dateHelper', () => {
    describe('getCurrentDate', () => {
        it('should return current date with time set to 00:00', () => {
            const currentDate = getCurrentDate();
            expect(currentDate.getHours()).toBe(0);
            expect(currentDate.getMinutes()).toBe(0);
            expect(currentDate.getSeconds()).toBe(0);
            expect(currentDate.getMilliseconds()).toBe(0);
        });
    });

    describe('getDate', () => {
        it('should return date with time set to 00:00', () => {
            const date = new Date(2021, 0, 1, 12, 30, 30, 30);
            const currentDate = getDate(date);
            expect(currentDate.getHours()).toBe(0);
            expect(currentDate.getMinutes()).toBe(0);
            expect(currentDate.getSeconds()).toBe(0);
            expect(currentDate.getMilliseconds()).toBe(0);
        });
    });

    describe('addDays', () => {
        it('should add days to date and set time to 00:00', () => {
            const date = new Date(2021, 0, 1);
            const nextDate = addDays(1, date);
            expect(nextDate.getDate()).toBe(2);
            expect(nextDate.getHours()).toBe(0);
            expect(nextDate.getMinutes()).toBe(0);
            expect(nextDate.getSeconds()).toBe(0);
            expect(nextDate.getMilliseconds()).toBe(0);
        });

        it('should add days to current date if date is not provided', () => {
            const currentDate = getCurrentDate();
            const nextDate = addDays(1);
            expect(nextDate.getDate()).toBe(currentDate.getDate() + 1);
            expect(nextDate.getHours()).toBe(0);
            expect(nextDate.getMinutes()).toBe(0);
            expect(nextDate.getSeconds()).toBe(0);
            expect(nextDate.getMilliseconds()).toBe(0);
        });
    });
});
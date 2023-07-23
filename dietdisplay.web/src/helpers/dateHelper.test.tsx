// dateHelper tests

import { getCurrentDate, getDate } from './dateHelper';

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
});
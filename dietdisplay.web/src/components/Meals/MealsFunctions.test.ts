import { getDate } from "../../helpers/dateHelper";
import { MealType } from "../models/Meal";
import { expandedByDefaultMealType } from "./MealsFunctions";
import MockedMeals from "./MockedMeals";

describe('MealsFunctions', () => {
    const generateRandomDates = (startTime: Date, endTime: Date) => {
        const today = new Date();
        const diffInMillis = endTime.getTime() - startTime.getTime();
        const result: Date[] = [];
        for (let i = 0; i < 5; i++) {
            const randomMillis = Math.floor(Math.random() * diffInMillis);
            const randomDate = new Date(startTime.getTime() + randomMillis);
            result.push(randomDate);
        }
        return result;
    }

    const today = getDate(new Date());

    it.each(generateRandomDates(new Date(today.getFullYear(), today.getMonth(), today.getDate(), 0, 0, 0, 0), new Date(today.getFullYear(), today.getMonth(), today.getDate(), 10, 30, 0, 0)))
        ('expandedByDefaultMealType should return Breakfast when now is between 00:00 and 10:30', (date) => {
            const result = expandedByDefaultMealType(MockedMeals, date);
            expect(result).toBe(MealType.Breakfast);
    });

    it.each(generateRandomDates(new Date(today.getFullYear(), today.getMonth(), today.getDate(), 10, 30, 0, 0), new Date(today.getFullYear(), today.getMonth(), today.getDate(), 13, 0, 0, 0)))
    ('expandedByDefaultMealType should return Dinner when now is between 10:30 and 13:00', (date) => {
        const result = expandedByDefaultMealType(MockedMeals, date);
        expect(result).toBe(MealType.Dinner);
    });

    it.each(generateRandomDates(new Date(today.getFullYear(), today.getMonth(), today.getDate(), 13, 0, 0, 0), new Date(today.getFullYear(), today.getMonth(), today.getDate(), 15, 30, 0, 0)))
    ('expandedByDefaultMealType should return Snack when now is between 13:00 and 15:30', (date) => {
        const result = expandedByDefaultMealType(MockedMeals, date);
        expect(result).toBe(MealType.Snack);
    });

    it.each(generateRandomDates(new Date(today.getFullYear(), today.getMonth(), today.getDate(), 15, 30, 0, 0), new Date(today.getFullYear(), today.getMonth(), today.getDate(), 23, 59, 59, 999)))
    ('expandedByDefaultMealType should return Supper for %s', (date) => {
        const result = expandedByDefaultMealType(MockedMeals, date);
        expect(result).toBe(MealType.Supper);
    });

});
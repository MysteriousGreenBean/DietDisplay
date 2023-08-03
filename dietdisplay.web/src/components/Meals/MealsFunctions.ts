import { getDate } from "../../helpers/dateHelper";
import { Meal, MealType } from "../models/Meal";

const dividePeriodIntoParts = (start: Date, end: Date, numberOfParts: number): Date[] => {
    const diffInMillis = end.getTime() - start.getTime();
    const intervalInMillis = diffInMillis / numberOfParts;
  
    const result: Date[] = [];
  
    const todayMidnight = getDate(start);
    result.push(todayMidnight);
  
    for (let i = 0; i <= numberOfParts - 1; i++) {
      const newDate = new Date(start.getTime() + intervalInMillis * i);
      result.push(newDate);
    }
  
    const endOfDay = new Date(todayMidnight.getFullYear(), todayMidnight.getMonth(), todayMidnight.getDate(), 23, 59, 59, 999);
    result.push(endOfDay);
  
    return result;
  }
  
const isBetween = (date: Date, startDate: Date, endDate: Date) => {
    return date >= startDate && date < endDate;
}
  
export const expandedByDefaultMealType = (meals: Meal[], now: Date) => {
    const firstMealTime = new Date(now);
    firstMealTime.setHours(10, 30, 0, 0);
    const lastMealTime = new Date(now);
    lastMealTime.setHours(18, 0, 0, 0);

    if (now < firstMealTime) 
        return meals[0].type;
    if (now > lastMealTime)
        return meals[meals.length - 1].type;

    const mealPeriods = dividePeriodIntoParts(firstMealTime, lastMealTime, meals.length - 1);
    const mealPeriodsWithTypes: { periodStart: Date, periodEnd: Date, mealType: MealType }[] = [];
    for (let i = 0; i < mealPeriods.length - 1; i++) {
        mealPeriodsWithTypes.push({
        periodStart: mealPeriods[i],
        periodEnd: mealPeriods[i + 1],
        mealType: meals[i].type
        });
    }
    const currentMealPeriod = mealPeriodsWithTypes.find((mealPeriodWithType) => isBetween(now, mealPeriodWithType.periodStart, mealPeriodWithType.periodEnd));
    return currentMealPeriod?.mealType ?? meals[0].type;
}
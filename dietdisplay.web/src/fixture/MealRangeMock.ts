import { MealRange } from "../components/models/MealRange";
import { addDays } from "../helpers/dateHelper";

export const MealRangeMock: MealRange = {
    oldestDate: addDays(-7),
    newestDate: addDays(30),
};
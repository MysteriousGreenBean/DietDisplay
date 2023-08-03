import { render, screen, waitFor } from "@testing-library/react";
import userEvent from '@testing-library/user-event';
import { Meal, MealType } from "../models/Meal";
import { Meals } from "./Meals";
import * as MealsFunctions from "./MealsFunctions";
import MockedMeals from "./MockedMeals";

jest.mock('./MealsFunctions');  

describe("Meals", () => {
    const renderMeals = (mealsToRender: Meal[]) => {
        render(<Meals meals={mealsToRender} />);
    };

    it("should render 'Brak posiłków' when no meals are provided", () => {
        renderMeals([]);
        expect(screen.getByText("Brak posiłków")).toBeInTheDocument();
    });

    it("should render meals when meals are provided", () => {
        renderMeals(MockedMeals);
        expect(screen.getByText(MealType.Breakfast)).toBeInTheDocument();
        expect(screen.getByText(MealType.Dinner)).toBeInTheDocument();
    });

    it("should show details about ingredients when meal is expanded", async () => {     
        jest.spyOn(MealsFunctions, 'expandedByDefaultMealType').mockImplementation(() =>  MealType.Breakfast);

        const user = userEvent.setup();
        renderMeals(MockedMeals);
        const dinnerCell = screen.getByText(MealType.Dinner);
        await waitFor(() => {
            expect(dinnerCell).toBeInTheDocument();
            expect(
                screen.queryByText("Makaron pełnoziarnisty")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Ser tarty")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Oliwa z oliwek")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Dynia, pestki")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Pomidory z puszki")
            ).not.toBeInTheDocument();
        });

        const expandButton = dinnerCell.parentElement!.querySelector('button[aria-label="expand row"]')!;
        await user.click(expandButton);
  
        await waitFor(() => {
            expect(dinnerCell).toBeInTheDocument();
            expect(
                screen.queryByText("Makaron pełnoziarnisty")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Ser tarty")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Oliwa z oliwek")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Dynia, pestki")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Pomidory z puszki")
            ).toBeInTheDocument();
        });
    });

    it("should hide details about ingredients when meal is collapsed", async () => {
        jest.spyOn(MealsFunctions, 'expandedByDefaultMealType').mockImplementation(() =>  MealType.Breakfast);

        const user = userEvent.setup();
        renderMeals(MockedMeals);
        const breakfastCell = screen.getByText(MealType.Breakfast);
        await waitFor(() => {
            expect(breakfastCell).toBeInTheDocument();
            expect(
                screen.queryByText("Mleko 2%")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Skyr Jogurt naturalny")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Borówki")
            ).toBeInTheDocument();
            expect(
                screen.queryByText("Orzechy nerkowca")
            ).toBeInTheDocument();
        });

        const expandButton = breakfastCell.parentElement!.querySelector('button[aria-label="expand row"]')!;
        await user.click(expandButton);
  
        await waitFor(() => {
            expect(
                screen.queryByText("Mleko 2%")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Skyr Jogurt naturalny")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Borówki")
            ).not.toBeInTheDocument();
            expect(
                screen.queryByText("Orzechy nerkowca")
            ).not.toBeInTheDocument();
        });
    }, );

    it.each([MealType.Breakfast, MealType.Dinner, MealType.Snack, MealType.Supper])("should expand %s by default", async (mealType) => {
        jest.spyOn(MealsFunctions, 'expandedByDefaultMealType').mockImplementation(() => mealType);
    
        renderMeals(MockedMeals);
        // read all ingredient names for mealType in mockMeals
        const ingredientNames = MockedMeals
            .find((meal) => meal.type === mealType)!
            .ingredients.map((ingredient) => ingredient.name);

        expect(screen.getByText(mealType)).toBeInTheDocument();
        await waitFor(() => {
            expect(screen.getByText(mealType)).toBeInTheDocument();
            ingredientNames.forEach((ingredientName) => {
                expect(screen.getByText(ingredientName)).toBeInTheDocument();
            });
        });
    });
})

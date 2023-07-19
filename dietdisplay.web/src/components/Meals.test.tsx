import { render, screen, waitFor } from "@testing-library/react";
import userEvent from '@testing-library/user-event';
import { Meals } from "./Meals";
import { Meal, MealType } from "./models/Meal";

const mockMeals: Meal[] = [
    {
        ingredients: [
            {
                name: "Mleko 2%",
                quantity: 100,
            },
            {
                name: "Skyr Jogurt naturalny",
                quantity: 150,
            },
            {
                name: "Borówki",
                quantity: 75,
            },
            {
                name: "Orzechy nerkowca",
                quantity: 25,
            },
        ],
        preparation:
            "Blendujemy mleko, orzechy, jogurt oraz borówki",
        type: MealType.Breakfast,
    },
    {
        ingredients: [
            {
                name: "Makaron pełnoziarnisty",
                quantity: 120,
            },
            {
                name: "Ser tarty",
                quantity: 20,
            },
            {
                name: "Oliwa z oliwek",
                quantity: 10,
            },
            {
                name: "Dynia, pestki",
                quantity: 120,
            },
            {
                name: "Pomidory z puszki",
                quantity: 200,
            },
        ],
        preparation:
            "Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory z puszki oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem.",
        type: MealType.Dinner,
    },
];

describe("Meals", () => {
    const renderMeals = (mealsToRender: Meal[]) => {
        render(<Meals meals={mealsToRender} />);
    };

    it("should render 'Brak posiłków' when no meals are provided", () => {
        renderMeals([]);
        expect(screen.getByText("Brak posiłków")).toBeInTheDocument();
    });

    it("should render meals when meals are provided", () => {
        renderMeals(mockMeals);
        expect(screen.getByText(MealType.Breakfast)).toBeInTheDocument();
        expect(screen.getByText(MealType.Dinner)).toBeInTheDocument();
    });

    it("should show details about ingredients when meal is expanded", async () => {     
        const user = userEvent.setup();
        renderMeals(mockMeals);
        const dinnerRow = screen.getByText(MealType.Dinner);
        expect(dinnerRow).toBeInTheDocument();
        expect(dinnerRow).toBeInTheDocument();
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
        const expandButton = dinnerRow.getElementsByTagName("button")[0];
        await user.click(expandButton);
  
        waitFor(() => {
            expect(dinnerRow).toBeInTheDocument();
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

    it("should expand breakfast details automatically", async () => {
        renderMeals(mockMeals);
        const breakfastRow = screen.getByText(MealType.Breakfast);
        expect(breakfastRow).toBeInTheDocument();
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

    it("should hide details about ingredients when meal is collapsed", async () => {
        const user = userEvent.setup();
        renderMeals(mockMeals);
        const breakfastRow = screen.getByText(MealType.Breakfast);
        expect(breakfastRow).toBeInTheDocument();
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

        
        const expandButton = breakfastRow.getElementsByTagName("button")[0];
        await user.click(expandButton);
  
        waitFor(() => {
            expect(
                screen.getByText("Mleko 2%")
            ).not.toBeInTheDocument();
            expect(
                screen.getByText("Skyr Jogurt naturalny")
            ).not.toBeInTheDocument();
            expect(
                screen.getByText("Borówki")
            ).not.toBeInTheDocument();
            expect(
                screen.getByText("Orzechy nerkowca")
            ).not.toBeInTheDocument();
        });
    });
})

import { Meal, MealType } from "../models/Meal";

const MockedMeals : Meal[] = [
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
    {
        ingredients: [
            {
                name: "Jabłko",
                quantity: 100,
            },
            {
                name: "Orzechy włoskie",
                quantity: 25,
            },
        ],
        preparation:
            "Pokroić jabłko w kostkę, dodać orzechy włoskie",
        type: MealType.Snack,
    },
    {
        ingredients: [
            {
                name: "Chleb żytni",
                quantity: 50,
            },
            {
                name: "Masło orzechowe",
                quantity: 20,
            },
            {
                name: "Banany",
                quantity: 100,
            },
        ],
        preparation:
            "Posmarować chleb masłem orzechowym, dodać pokrojonego banana",
        type: MealType.Supper,
    }
];

export default MockedMeals;
import { Meal, MealType } from "../components/models/Meal";

export const MealsMock: Meal[] = [
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
      preparation: "Blendujemy mleko, orzechy, jogurt oraz borówki",
      type: MealType.Breakfast,
    },
    {
      ingredients: [
        {
          name: 'Makaron pełnoziarnisty',
          quantity: 120,
        },
        {
          name: 'Ser tarty',
          quantity: 20,
        },
        {
          name: 'Oliwa z oliwek',
          quantity: 10,
        },
        {
          name: 'Dynia, pestki',
          quantity: 120,
        },
        {
          name: 'Pomidory z puszki',
          quantity: 200,
        },
      ],
      preparation: 'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory z puszki oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem.',
      type: MealType.Dinner,
    }
  ];
  
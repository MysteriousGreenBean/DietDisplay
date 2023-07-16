export interface Meal {
    ingredients: Ingredient[];
    preparation: string;
    type: MealType;
}

export interface Ingredient {
    name: string;
    quantity: number;
}

export enum MealType {
    Breakfast = "Śniadanie",
    SecondBreakfast = "Drugie śniadanie",
    Dinner = "Obiad",
    Tea = "Podwieczorek",
    Supper = "Kolacja",
    Snack = "Przekąska"
}
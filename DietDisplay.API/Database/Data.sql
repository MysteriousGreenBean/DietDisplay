INSERT INTO Meals (ID, Preparation, MealType, DayID)
VALUES
    (1, 'Blendujemy mleko, orzechy, jogurt oraz borówki', 'Śniadanie', 1),
    (2, 'Przekąska', 'Drugie Śniadanie', 1),
    (3, 'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory w puszce oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem', 'Obiad', 1),
    (4, 'Jajecznica / Sadzone / Trzy jaja klasy M, chleb z pełnego ziarna', 'Kolacja', 1);


INSERT INTO Ingredients (ID, Name, Quantity, MealID)
VALUES
    -- Śniadanie
    (1, 'Mleko 2%', 100, 1),
    (2, 'Skyr Jogurt Naturalny', 150, 1),
    (3, 'Borówki', 75, 1),
    (4, 'Orzechy nerkowca', 25, 1),
    -- Drugie Śniadanie
    (5, 'Serek wiejski', 200, 2),
    (6, 'Orzechy Nerkowca', 20, 2),
    (7, 'Chleb orkiszowy', 60, 2),
    -- Obiad
    (8, 'Makaron pełnoziarnisty', 120, 3),
    (9, 'Ser tarty', 20, 3),
    (10, 'Oliwa z oliwek', 10, 3),
    (11, 'Dynia, pestki', 20, 3),
    (12, 'Pomidory z puszki', 200, 3),
    -- Kolacja
    (13, 'Jaja kurze całe', 150, 4),
    (14, 'Chleb żytni razowy', 100, 4),
    (15, 'Oliwa z oliwek', 15, 4),
    (16, 'Pomidor', 200, 4);

INSERT INTO DayMeals (Date, DayID)
VALUES ('2023-07-18', 1);
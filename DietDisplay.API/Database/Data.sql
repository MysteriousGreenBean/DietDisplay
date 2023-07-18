INSERT INTO Meals (ID, Preparation, MealType, DayID)
VALUES
    (1, N'Blendujemy mleko, orzechy, jogurt oraz borówki', N'Śniadanie', 1),
    (2, N'Przekąska', N'Drugie śniadanie', 1),
    (3, N'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory w puszce oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem', N'Obiad', 1),
    (4, N'Jajecznica / Sadzone / Trzy jaja klasy M, chleb z pełnego ziarna', N'Kolacja', 1);


INSERT INTO Ingredients (ID, Name, Quantity, MealID)
VALUES
    -- Śniadanie
    (1, N'Mleko 2%', 100, 1),
    (2, N'Skyr Jogurt Naturalny', 150, 1),
    (3, N'Borówki', 75, 1),
    (4, N'Orzechy nerkowca', 25, 1),
    -- Drugie Śniadanie
    (5, N'Serek wiejski', 200, 2),
    (6, N'Orzechy Nerkowca', 20, 2),
    (7, N'Chleb orkiszowy', 60, 2),
    -- Obiad
    (8, N'Makaron pełnoziarnisty', 120, 3),
    (9, N'Ser tarty', 20, 3),
    (10, N'Oliwa z oliwek', 10, 3),
    (11, N'Dynia, pestki', 20, 3),
    (12, N'Pomidory z puszki', 200, 3),
    -- Kolacja
    (13, N'Jaja kurze całe', 150, 4),
    (14, N'Chleb żytni razowy', 100, 4),
    (15, N'Oliwa z oliwek', 15, 4),
    (16, N'Pomidor', 200, 4);

INSERT INTO DayMeals (Date, DayID)
VALUES ('2023-07-18', 1);
INSERT INTO Meals (ID, Preparation, MealType, DayID)
VALUES
    (1, N'Blendujemy mleko, orzechy, jogurt oraz borówki', N'Śniadanie', 1),
    (2, N'Przekąska', N'Drugie śniadanie', 1),
    (3, N'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory w puszce oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem', N'Obiad', 1),
    (4, N'Jajecznica / Sadzone / Trzy jaja klasy M, chleb z pełnego ziarna', N'Kolacja', 1),
    (5, N'Kanapki z twarogiem półtłustym i warzywami', N'Śniadanie', 10),
    (6, N'Sałatka z upieczonymi kawałkami kurczaka, oliwą, pomidorkami koktajlowymi i mixem salat. Chleb 30g pokroić w kosteczkę i podpiec w stylu grzanek', N'Obiad', 10),
    (7, N'Przekąska', N'Podwieczorek', 10),
    (8, N'Kanapki z humusem, ugotowanymi jajkami i ogórkiem (dwa jaja klasy M)', N'Kolacja', 10);


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

    INSERT INTO Ingredients (ID, Name, Quantity, MealID)
VALUES
    (17, N'Chleb żytni razowy', 250, 5),
    (18, N'Ser twarogowy półtłusty', 125, 5),
    (19, N'Szczypiorek', 20, 5),
    (20, N'Ogórek', 100, 5);

-- For the meal with ID 6 (Obiad)
INSERT INTO Ingredients (ID, Name, Quantity, MealID)
VALUES
    (21, N'Mix Sałat', 100, 6),
    (22, N'Mięso z piersi kurczaka bez skóry', 250, 6),
    (23, N'Oliwa z oliwek', 15, 6),
    (24, N'Pomidorki koktajlowe', 100, 6),
    (25, N'Ser tarty', 10, 6),
    (26, N'Chleb żytni razowy', 30, 6);

-- For the meal with ID 7 (Podwieczorek)
INSERT INTO Ingredients (ID, Name, Quantity, MealID)
VALUES
    (27, N'Gorzka czekolada', 30, 7),
    (28, N'Borówki', 75, 7),
    (29, N'Serek Wiejski', 200, 7);

-- For the meal with ID 8 (Kolacja)
INSERT INTO Ingredients (ID, Name, Quantity, MealID)
VALUES
    (30, N'Chleb żytni razowy', 200, 8),
    (31, N'Jaja gotowane', 150, 8),
    (32, N'Hummus', 50, 8),
    (33, N'Ogórek', 200, 8);

INSERT INTO DayMeals (Date, DayID)
VALUES ('2023-07-18', 1);
-- Declare and populate the table variables for Meals and Ingredients
DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;

-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Blendujemy mleko, orzechy, jogurt oraz borówki', 1),
    (N'Drugie Śniadanie', N'Przekąska', 1),
    (N'Obiad', N'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory z puszki oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem', 1),
    (N'Kolacja', N'Jajecznica / Sadzone / Trzy jaja klasy M, chleb z pełnego ziarna', 1);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Mleko 2%', 100),
    (N'Śniadanie', N'Skyr Jogurt Naturalny', 150),
    (N'Śniadanie', N'Borówki', 75),
    (N'Śniadanie', N'Orzechy nerkowca', 25),

    -- Drugie Śniadanie
    (N'Drugie Śniadanie', N'Serek wiejski', 200),
    (N'Drugie Śniadanie', N'Orzechy Nerkowca', 20),
    (N'Drugie Śniadanie', N'Chleb orkiszowy', 60),

    -- Obiad
    (N'Obiad', N'Makaron pełnoziarnisty', 120),
    (N'Obiad', N'Ser tarty', 20),
    (N'Obiad', N'Oliwa z oliwek', 10),
    (N'Obiad', N'Dynia, pestki', 20),
    (N'Obiad', N'Pomidory z puszki', 200),

    -- Kolacja
    (N'Kolacja', N'Jaja kurze całe', 150),
    (N'Kolacja', N'Chleb żytni razowy', 100),
    (N'Kolacja', N'Oliwa z oliwek', 15),
    (N'Kolacja', N'Pomidor', 200);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z szynką i warzywami – dowolny hummus jako smarowidło', 2),
    (N'Obiad', N'Gotujemy kaszę w lekko osolonej wodzie, doprawioną przyprawami wołowinę dusimy przez 10 minut na patelni z oliwą i szpinakiem ciągle mieszając. Dodajemy pokrojone pomidorki, dusimy całość przez 2-3 minuty. Na koniec dodajemy gotową kaszę, mieszamy całe danie i przekładamy na talerz / pojemnik. Zamiennie Ryż 100g / Makaron pełnoziarnisty 100g', 2),
    (N'Podwieczorek', N'Maliny mrożone podgrzać w mikrofalówce i dodać do jogurtu', 2),
    (N'Kolacja', N'Kanapki z Hummusem, szynką i ogórkiem Chleb żytni zamiennie z orkiszowym, najważniejsze aby gramatura się zgadzała.', 2);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb żytni razowy', 200),
    (N'Śniadanie', N'Hummus', 50),
    (N'Śniadanie', N'Szynka z piersi kurczaka', 70),
    (N'Śniadanie', N'Pomidor', 100),
    (N'Śniadanie', N'Ogórek', 100),
    (N'Śniadanie', N'Rukola', 20),

    -- Obiad
    (N'Obiad', N'Kasza gryczana', 100),
    (N'Obiad', N'Wołowina mielona', 200),
    (N'Obiad', N'Oliwa z oliwek', 10),
    (N'Obiad', N'Szpinak', 50),
    (N'Obiad', N'Pomidory koktajlowe', 100),

    -- Podwieczorek
    (N'Podwieczorek', N'Skyr Jogurt Naturalny', 300),
    (N'Podwieczorek', N'Maliny, mrożone', 200),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Hummus', 50),
    (N'Kolacja', N'Szynka z piersi kurczaka', 60),
    (N'Kolacja', N'Ogórek', 150);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z twarogiem półtłustym i dżemem niskosłodzonym', 3),
    (N'Obiad', N'Sałatka z upieczoną piersią z kurczaka, mozarellą, oliwą, pomidorem - chleb 30g pokroić w kosteczkę i podpiec w stylu grzanek (opcjonalnie)', 3),
    (N'Podwieczorek', N'Przekąska w postaci orzechów i truskawek', 3),
    (N'Kolacja', N'Kanapki z humusem, ugotowanymi jajkami i ogórkiem (trzy jaja klasy M)', 3);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb orkiszowy', 200),
    (N'Śniadanie', N'Ser twarogowy półtłusty', 125),
    (N'Śniadanie', N'Dżem niskosłodzony', 30),

    -- Obiad
    (N'Obiad', N'Mix Sałat', 100),
    (N'Obiad', N'Mięso z piersi kurczaka', 200),
    (N'Obiad', N'Mozarella light', 50),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Pomidor', 200),
    (N'Obiad', N'Chleb żytni razowy', 30),

    -- Podwieczorek
    (N'Podwieczorek', N'Orzechy Nerkowca', 50),
    (N'Podwieczorek', N'Truskawki', 400),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Jaja gotowane', 150),
    (N'Kolacja', N'Hummus', 50),
    (N'Kolacja', N'Ogórek', 100);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z mozarellą, pomidorem, delikatnie polane oliwą we Włoskim stylu', 4),
    (N'Obiad', N'Gotujemy makaron (zamiennie z kaszą gryczaną – gramatura ta sama). Na patelni na oliwie podsmażamy przygotowane kawałki mięsa, dodajemy pomidory w puszce, liście szpinaku – dusimy 5 minut', 4),
    (N'Podwieczorek', N'Przekąska', 4),
    (N'Kolacja', N'Wymieszać wszystkie składniki i odstawić na 20 minut', 4);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb żytni razowy', 200),
    (N'Śniadanie', N'Mozarella light', 50),
    (N'Śniadanie', N'Oliwa z oliwek', 5),
    (N'Śniadanie', N'Pomidor', 200),

    -- Obiad
    (N'Obiad', N'Makaron pełnoziarnisty', 120),
    (N'Obiad', N'Mięso z piersi kurczaka', 200),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Pomidory w puszce', 200),
    (N'Obiad', N'Szpinak', 50),

    -- Podwieczorek
    (N'Podwieczorek', N'Pomarańcza', 300),
    (N'Podwieczorek', N'Orzechy włoskie', 30),

    -- Kolacja
    (N'Kolacja', N'Jogurt naturalny 2% tłuszczu', 300),
    (N'Kolacja', N'Borówki / Maliny', 50),
    (N'Kolacja', N'Płatki owsiane błyskawiczne', 100),
    (N'Kolacja', N'Orzechy nerkowca', 30);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kaszę mannę gotujemy na mleku aż do spęcznienia kaszy – można dodać trochę wody przed zagotowaniem (300g mleka + 200g wody). Do gotowej kaszy dodajemy umyte borówki oraz orzechy.', 5),
    (N'Drugie Śniadanie', N'Jabłko (300g), Kefir 2% (500g)', 5),
    (N'Obiad', N'Pierś z indyka usmażyć na oliwie, dodać pieczarki i również je podsmażyć, dodać pomidory w puszce oraz szpinak – dusic 5-6 minut. Ugotować kaszę gryczaną w lekko posolonej wodzie', 5),
    (N'Kolacja', N'Sałatka z mozarella, oliwą, pomidorem, pestkami dyni, chleb 30g pokroić w kosteczkę i podpiec w stylu grzanek. Wszystkie składniki mieszamy ze sobą.', 5);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Kasza manna', 100),
    (N'Śniadanie', N'Mleko 2%', 400),
    (N'Śniadanie', N'Orzechy nerkowca', 30),
    (N'Śniadanie', N'Borówki', 75),

    -- Drugie Śniadanie
    (N'Drugie Śniadanie', N'Jabłko', 300),
    (N'Drugie Śniadanie', N'Kefir 2%', 500),

    -- Obiad
    (N'Obiad', N'Mięso z piersi indyka, bez skóry', 200),
    (N'Obiad', N'Kasza gryczana', 100),
    (N'Obiad', N'Oliwa z oliwek', 20),
    (N'Obiad', N'Pomidory w puszce', 100),
    (N'Obiad', N'Szpinak', 50),
    (N'Obiad', N'Pieczarki', 50),

    -- Kolacja
    (N'Kolacja', N'Mix Sałat', 100),
    (N'Kolacja', N'Mozarella light', 50),
    (N'Kolacja', N'Oliwa z oliwek', 15),
    (N'Kolacja', N'Pomidory koktajlowe', 100),
    (N'Kolacja', N'Dynia, pestki', 20),
    (N'Kolacja', N'Chleb żytni razowy', 50);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Wymieszać wszystkie składniki i odstawić na 20 minut', 6),
    (N'Obiad', N'Gotujemy kaszę jaglaną w 400 g mleka 2% oraz 100-200g wody. Do ugotowanej kaszy dodajemy pokrojone jabłko oraz orzechy. W razie potrzeby słodzimy ksylitolem', 6),
    (N'Przekąska', N'Przekąska', 6),
    (N'Kolacja', N'Makaron ugotować w osolonej wodzie, wrzucić na patelni z oliwą, dodać pesto oraz posiekane nerkowce i wymieszać przez 2-3 minuty', 6);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Jogurt naturalny 2% tłuszczu', 300),
    (N'Śniadanie', N'Borówka amerykańska', 60),
    (N'Śniadanie', N'Płatki owsiane błyskawiczne', 100),
    (N'Śniadanie', N'Orzech włoski', 30),

    -- Obiad
    (N'Obiad', N'Kasza jaglana', 100),
    (N'Obiad', N'Mleko spożywcze, 2% tłuszczu', 400),
    (N'Obiad', N'Jabłko', 200),
    (N'Obiad', N'Orzechy Brazylijskie', 40),

    -- Przekąska
    (N'Przekąska', N'Skyr Jogurt Naturalny', 300),
    (N'Przekąska', N'Truskawki', 300),

    -- Kolacja
    (N'Kolacja', N'Makaron pełnoziarnisty', 120),
    (N'Kolacja', N'Pesto', 50),
    (N'Kolacja', N'Oliwa z oliwek', 15),
    (N'Kolacja', N'Orzechy Nerkowca', 20);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Owsianka\nPłatki owsiane zalać gorącym mlekiem, dodać maliny i orzechy i odstawić pod przykryciem na 20 minut.', 7),
    (N'Przekąska', N'Przekąska', 7),
    (N'Obiad', N'Rybę przyprawiamy solą, pieprzem i przyprawioną rybę przekładamy do naczynia żaroodpornego, wlewamy oliwę i przykrywamy. Przygotowaną rybę pieczemy w piekarniku rozgrzanym do 180 stopni (termoobieg) przez około 15 – 20 minut. Ziemniaki gotujemy w lekko osolonej wodzie, wykładamy wszystko i dodajemy pokrojonego pomidora– uważamy na ilość soli w przyprawach.', 7),
    (N'Kolacja', N'Kanapki z szynką, rukolą, hummusem i ogórkiem', 7);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Mleko 2%', 400),
    (N'Śniadanie', N'Płatki owsiane błyskawiczne', 100),
    (N'Śniadanie', N'Maliny', 50),
    (N'Śniadanie', N'Orzechy brazylijskie', 30),

    -- Przekąska
    (N'Przekąska', N'Jogurt roślinny ALPRO', 400),
    (N'Przekąska', N'Migdały', 30),

    -- Obiad
    (N'Obiad', N'Mintaj / Dorsz', 100),
    (N'Obiad', N'Ziemniaki', 400),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Pomidor', 200),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Szynka z piersi kurczaka', 60),
    (N'Kolacja', N'Hummus', 50),
    (N'Kolacja', N'Rukola', 20),
    (N'Kolacja', N'Ogórek', 200);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Na oliwie podsmażamy pomidory z puszki, dodajemy trzy jaja klasy M, dusimy pod przykryciem a’la szakszuka. Podajemy z chlebem.', 8),
    (N'Drugie Śniadanie', N'Drugie Śniadanie', 8),
    (N'Obiad', N'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory w puszce oraz pestki dyni, zamieszać, do calości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem.', 8),
    (N'Przekąska', N'Przekąska', 8),
    (N'Kolacja', N'Kanapki z humusem, ugotowanymi jajkami i ogórkiem ( dwa jaja klasy M )', 8);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Jaja kurze całe', 150),
    (N'Śniadanie', N'Pomidory z puszki', 100),
    (N'Śniadanie', N'Oliwa z oliwek', 10),
    (N'Śniadanie', N'Chleb żytni razowy', 120),

    -- Drugie Śniadanie
    (N'Drugie Śniadanie', N'Serek wiejski', 200),
    (N'Drugie Śniadanie', N'Chleb orkiszowy', 80),

    -- Obiad
    (N'Obiad', N'Makaron pełnoziarnisty', 120),
    (N'Obiad', N'Ser tarty', 10),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Dynia, pestki', 20),
    (N'Obiad', N'Pomidory z puszki', 100),

    -- Przekąska
    (N'Przekąska', N'Orzechy Włoskie', 30),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Jaja gotowane', 100),
    (N'Kolacja', N'Hummus', 30),
    (N'Kolacja', N'Ogórek', 100);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z hummusem, chudą szynką z kurczaka, pomidorem i rukola', 9),
    (N'Przekąska', N'Przekąska', 9),
    (N'Obiad', N'Mięso z kurczaka polewamy oliwą, pieczemy w piekarniku, dodajemy przyprawy ( mięso może być wcześniej zamarynowane ) – limitujemy sól. Gotujemy ziemniaki w lekko osolonej wodzie oraz brokuł. Upieczone mięso i gotowe ziemniaki podajemy z brokułem.', 9),
    (N'Kolacja', N'Kanapki z twarogiem i warzywami', 9);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb żytni razowy', 200),
    (N'Śniadanie', N'Hummus', 50),
    (N'Śniadanie', N'Szynka z piersi kurczaka', 50),
    (N'Śniadanie', N'Pomidor', 100),
    (N'Śniadanie', N'Rukola', 25),

    -- Przekąska
    (N'Przekąska', N'Orzechy Nerkowca', 30),
    (N'Przekąska', N'Borówki', 125),

    -- Obiad
    (N'Obiad', N'Mięso z piersi kurczaka, bez skóry', 200),
    (N'Obiad', N'Ziemniaki', 400),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Brokuły', 200),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Ser twarogowy półtłusty', 125),
    (N'Kolacja', N'Szczypiorek', 20),
    (N'Kolacja', N'Papryka', 100);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z twarogiem półtłustym i warzywami', 10),
    (N'Obiad', N'Sałatka z upieczonymi kawałkami kurczaka, oliwą, pomidorkami koktajlowymi i mixem sałat. Chleb 30g pokroić w kosteczkę i podpiec w stylu grzanek', 10),
    (N'Podwieczorek', N'Przekąska', 10),
    (N'Kolacja', N'Kanapki z humusem, ugotowanymi jajkami i ogórkiem ( dwa jaja klasy M )', 10);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb żytni razowy', 250),
    (N'Śniadanie', N'Ser twarogowy półtłusty', 125),
    (N'Śniadanie', N'Szczypiorek', 20),
    (N'Śniadanie', N'Ogórek', 100),

    -- Obiad
    (N'Obiad', N'Mix Sałat', 100),
    (N'Obiad', N'Mięso z piersi kurczaka bez skóry', 250),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Pomidorki koktajlowe', 100),
    (N'Obiad', N'Ser tarty', 10),
    (N'Obiad', N'Chleb żytni razowy', 30),

    -- Podwieczorek
    (N'Podwieczorek', N'Gorzka czekolada', 30),
    (N'Podwieczorek', N'Borówki', 75),
    (N'Podwieczorek', N'Serek Wiejski', 200),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Jaja gotowane', 150),
    (N'Kolacja', N'Hummus', 50),
    (N'Kolacja', N'Ogórek', 200);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Wymieszać płatki owsiane w jogurcie, odstawić na 20 minut. Następnie umyte borówki i orzechy.', 11),
    (N'Obiad', N'Ugotować makaron w lekko osolonej wodzie, na patelni z oliwą dodać pomidory w puszce oraz pestki dyni, zamieszać, do całości dodać ugotowany i odsączony makaron – dusić kilka minut. Całość posypać tartym serem.', 11),
    (N'Podwieczorek', N'Jogurt z owocami', 11),
    (N'Kolacja', N'Jajecznica bądź jajka sadzone – do wyboru. Chleb żytni razowy zamienny z chlebem orkiszowym.', 11);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Skyr Jogurt Naturalny', 300),
    (N'Śniadanie', N'Płatki owsiane błyskawiczne', 100),
    (N'Śniadanie', N'Borówki', 50),
    (N'Śniadanie', N'Orzechy nerkowca', 30),

    -- Obiad
    (N'Obiad', N'Makaron pełnoziarnisty', 120),
    (N'Obiad', N'Ser tarty', 15),
    (N'Obiad', N'Oliwa z oliwek', 10),
    (N'Obiad', N'Dynia, pestki', 20),
    (N'Obiad', N'Pomidory z puszki', 200),

    -- Podwieczorek
    (N'Podwieczorek', N'Skyr Jogurt Naturalny', 150),
    (N'Podwieczorek', N'Kiwi', 100),
    (N'Podwieczorek', N'Jabłko', 150),

    -- Kolacja
    (N'Kolacja', N'Jaja kurze całe', 200),
    (N'Kolacja', N'Chleb żytni razowy', 150),
    (N'Kolacja', N'Oliwa z oliwek', 10),
    (N'Kolacja', N'Ogórek', 200);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Na oliwie podsmażamy pomidory z puszki, dodajemy trzy jaja klasy M, dusimy pod przykryciem a’la szakszuka. Podajemy z chlebem.', 12),
    (N'Drugie śniadanie', N'', 12),
    (N'Obiad', N'Łosoś wędzony – wystarczy go upiec przez 10 minut bowiem jest już lekko obrobiony termicznie. Jeśli łosoś surowy – pieczemy 25-30 minut. Ziemniaczki możemy upiec w piekarniku bądź ugotować. Oliwa do wykorzystania do pieczenia łososia bądź ziemniaków.', 12),
    (N'Podwieczorek', N'Maliny mrożone podgrzać w mikrofalówce i dodać do jogurtu.', 12),
    (N'Kolacja', N'Kanapki z Hummusem, szynką i papryką.', 12);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Jaja kurze całe', 150),
    (N'Śniadanie', N'Pomidory z puszki', 100),
    (N'Śniadanie', N'Oliwa z oliwek', 10),
    (N'Śniadanie', N'Chleb orkiszowy', 120),

    -- Drugie śniadanie
    (N'Drugie śniadanie', N'Skyr Jogurt Naturalny', 150),

    -- Obiad
    (N'Obiad', N'Łosoś, wędzony', 100),
    (N'Obiad', N'Ziemniaki', 400),
    (N'Obiad', N'Cytryna', 25),
    (N'Obiad', N'Oliwa z oliwek', 10),
    (N'Obiad', N'Papryka', 200),

    -- Podwieczorek
    (N'Podwieczorek', N'Skyr Jogurt Naturalny', 300),
    (N'Podwieczorek', N'Maliny, mrożone', 200),

    -- Kolacja
    (N'Kolacja', N'Chleb żytni razowy', 200),
    (N'Kolacja', N'Hummus', 50),
    (N'Kolacja', N'Szynka z kurczaka', 80),
    (N'Kolacja', N'Papryka czerwona', 150);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z mozarellą, pomidorem, delikatnie polane oliwą we Włoskim stylu', 13),
    (N'Obiad', N'Gotujemy kasze gryczaną zgodnie z opisem na opakowaniu. Na patelni na oliwie podmażamy przygotowane kawałki indyka przez 10 minut, dodajemy kawałki papryki i dusimy 5 minut.', 13),
    (N'Podwieczorek', N'Zdjęcie jogurtu na dole', 13),
    (N'Kolacja', N'Gotujemy makaron zgodnie z opisem na opakowaniu. Do gotowego makaronu dodajemy serek wiejski, borówki i całość mieszamy. Serek wiejski zamiennie z jogurtem Naturalnym.', 13);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb żytni razowy', 200),
    (N'Śniadanie', N'Mozarella light', 50),
    (N'Śniadanie', N'Oliwa z oliwek', 10),
    (N'Śniadanie', N'Pomidor', 200),

    -- Obiad
    (N'Obiad', N'Kasza gryczana', 100),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Mięso z piersi indyka bez skóry', 200),
    (N'Obiad', N'Papryka', 200),

    -- Podwieczorek
    (N'Podwieczorek', N'Truskawki', 300),
    (N'Podwieczorek', N'Jogurt Proteinowy Pilos', 330),

    -- Kolacja
    (N'Kolacja', N'Makaron pełnoziarnisty', 120),
    (N'Kolacja', N'Borówki', 50),
    (N'Kolacja', N'Serek wiejski', 200);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki', 14),
    (N'Drugie Śniadanie', N'Przekąska', 14),
    (N'Obiad', N'Gotujemy makaron w lekko osolonej wodzie, na oliwie podsmażamy pomidorki, dodajemy ugotowany makaron oraz pesto – całość mieszamy 2-3 minuty', 14),
    (N'Kolacja', N'W garnku rozgrzewamy oliwę z oliwek(10g) i dusimy na niej cebulę. Dodajemy pomidory z puszki, odrobinę wody i gotujemy przez ok 10 minut. Po 10 minutach miksujemy ze sobą wszystkie składniki na gładką zupę i przyprawiamy delikatnie solą, pieprzem. Gotowy krem pomidorowy podajemy w miseczce posypany pestkami dyni, skrapiamy oliwą (5g) z oliwek oraz posypujemy serem tartym. Dodajemy podpieczony chleb na wzór grzanki.', 14);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb orkiszowy', 200),
    (N'Śniadanie', N'Hummus', 50),
    (N'Śniadanie', N'Szynka z piersi kurczaka', 60),
    (N'Śniadanie', N'Ser żółty', 50),
    (N'Śniadanie', N'Sałata / Rukola', 20),
    (N'Śniadanie', N'Ogórek', 100),
    (N'Śniadanie', N'Pomidor', 100),

    -- Drugie Śniadanie
    (N'Drugie Śniadanie', N'Jabłko', 200),
    (N'Drugie Śniadanie', N'Kiwi', 70),
    (N'Drugie Śniadanie', N'Skyr Jogurt Naturalny', 150),

    -- Obiad
    (N'Obiad', N'Makaron pełnoziarnisty', 150),
    (N'Obiad', N'Pesto zielone', 60),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Pomidorki koktajlowe', 100),
    (N'Obiad', N'Ser tarty', 15),

    -- Kolacja
    (N'Kolacja', N'Pomidory z puszki', 400),
    (N'Kolacja', N'Oliwa z oliwek', 15),
    (N'Kolacja', N'Cebula', 30),
    (N'Kolacja', N'Dynia, pestki', 15),
    (N'Kolacja', N'Chleb żytni razowy', 50);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Owsianka', 15),
    (N'Obiad', N'Ryba przyprawiamy solą, pieprzem i Przyprawioną rybę przekładamy do naczynia żaroodpornego, wlewamy oliwę i przykrywamy. Przygotowaną rybę pieczemy w piekarniku rozgrzanym do 180 stopni (termoobieg) przez około 15 – 20 minut. Gotujemy kaszę gryczaną, kroimy ogórka. Całość podajemy z cytryną.', 15),
    (N'Podwieczorek', N'Maliny mrożone podgrzać w mikrofalówce i dodać do jogurtu.', 15),
    (N'Kolacja', N'Kanapki z Hummusem, szynką i papryką', 15);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Mleko spożywcze, 2% tłuszczu', 300),
    (N'Śniadanie', N'Płatki owsiane', 120),
    (N'Śniadanie', N'Maliny', 50),
    (N'Śniadanie', N'Gorzka czekolada', 30),

    -- Obiad
    (N'Obiad', N'Dorsz, świeży, filety bez skóry', 100),
    (N'Obiad', N'Cytryna', 25),
    (N'Obiad', N'Kasza gryczana', 100),
    (N'Obiad', N'Oliwa z oliwek', 15),
    (N'Obiad', N'Ogórek', 200),

    -- Podwieczorek
    (N'Podwieczorek', N'Skyr Jogurt Naturalny', 300),
    (N'Podwieczorek', N'Maliny, mrożone', 200),

    -- Kolacja
    (N'Kolacja', N'Chleb orkiszowy', 250),
    (N'Kolacja', N'Hummus', 50),
    (N'Kolacja', N'Szynka z kurczaka', 60),
    (N'Kolacja', N'Papryka czerwona', 150);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO

DECLARE @Meals MealsTableType;
DECLARE @Ingredients IngredientsTableType;
-- Insert data for Śniadanie
INSERT INTO @Meals (MealType, Preparation, DayID)
VALUES
    (N'Śniadanie', N'Kanapki z twarogiem półtłustym i warzywami', 16),
    (N'Drugie Śniadanie', N'Przekąska', 16),
    (N'Obiad', N'Gotujemy kaszę jaglaną w 300 g mleka 2% oraz 300g wody. Do ugotowanej kaszy dodajemy pokrojone jabłko i miód, całość posypujemy cynamonem.', 16),
    (N'Kolacja', N'Na oliwie podsmażamy pomidory z puszki, dodajemy cztery jaja klasy M, dusimy pod przykryciem a’la szakszuka. Podajemy z chlebem.', 16);

-- Insert data for Ingredients
INSERT INTO @Ingredients (MealType, Name, Quantity)
VALUES
    -- Śniadanie
    (N'Śniadanie', N'Chleb żytni razowy', 200),
    (N'Śniadanie', N'Ser twarogowy półtłusty', 125),
    (N'Śniadanie', N'Pomidor', 200),
    (N'Śniadanie', N'Szczypiorek', 20),

    -- Drugie Śniadanie
    (N'Drugie Śniadanie', N'Bułka grahamka', 90),
    (N'Drugie Śniadanie', N'Serek wiejski', 200),

    -- Obiad
    (N'Obiad', N'Kasza jaglana', 100),
    (N'Obiad', N'Mleko spożywcze, 2% tłuszczu', 300),
    (N'Obiad', N'Jabłko', 300),
    (N'Obiad', N'Miód', 30),
    (N'Obiad', N'Cynamon', 1),

    -- Kolacja
    (N'Kolacja', N'Jaja kurze całe', 200),
    (N'Kolacja', N'Pomidory z puszki', 100),
    (N'Kolacja', N'Oliwa z oliwek', 15),
    (N'Kolacja', N'Chleb żytni razowy', 120);

-- Call the stored procedure with the table variables as parameters
EXEC InsertMealsAndIngredients @Meals, @Ingredients;
GO
CREATE TYPE MealsTableType AS TABLE (
    MealType NVARCHAR(20) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    Preparation NVARCHAR(500) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    DayID INT
);

CREATE TYPE IngredientsTableType AS TABLE (
    MealType NVARCHAR(20) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    Name NVARCHAR(50) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    Quantity INT
);
GO

CREATE PROCEDURE InsertMealsAndIngredients
    @Meals MealsTableType READONLY,
    @Ingredients IngredientsTableType READONLY
AS
BEGIN
    -- Temporary table to store generated Meal IDs and corresponding MealTypes
    CREATE TABLE #GeneratedMeals (MealID INT, MealType NVARCHAR(20) COLLATE Latin1_General_100_CI_AS_SC_UTF8);

    -- INSERT INTO Meals and capture generated Meal IDs and MealTypes
    MERGE INTO Meals AS target
    USING @Meals AS source
    ON 1 = 0 -- This ensures an insert-only operation
    WHEN NOT MATCHED THEN
    INSERT (Preparation, MealType, DayID)
    VALUES (source.Preparation, source.MealType, source.DayID)
    OUTPUT INSERTED.ID, INSERTED.MealType INTO #GeneratedMeals;

    -- INSERT INTO Ingredients using the captured Meal IDs from the temporary table
    INSERT INTO Ingredients (Name, Quantity, MealID)
    SELECT i.Name, i.Quantity, gm.MealID
    FROM @Ingredients AS i
    INNER JOIN #GeneratedMeals AS gm ON i.MealType = gm.MealType;

    -- Drop the temporary table
    DROP TABLE #GeneratedMeals;
END;
GO

CREATE TABLE Meals (
    ID INT PRIMARY KEY,
    Preparation NVARCHAR(500) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    MealType NVARCHAR(20) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    DayID INT
);

CREATE TABLE Ingredients (
    ID INT PRIMARY KEY,
    Name NVARCHAR(50) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    Quantity INT,
    MealID INT,
    FOREIGN KEY (MealID) REFERENCES Meals(ID)
);

CREATE TABLE DayMeals (
    Date DATE PRIMARY KEY,
    DayID INT
);

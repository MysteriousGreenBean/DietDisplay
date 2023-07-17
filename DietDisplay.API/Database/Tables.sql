CREATE TABLE Meals (
    ID INT PRIMARY KEY,
    Preparation NVARCHAR(500),
    MealType NVARCHAR(20)
);

CREATE TABLE Ingredients (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Quantity INT,
    MealID INT,
    FOREIGN KEY (MealID) REFERENCES Meals(ID)
);

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Farm')
BEGIN
    CREATE DATABASE Farm;
END
GO

USE Farm;
GO

CREATE TABLE Chicken (
    ChickenID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Breed NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    EggProduction DECIMAL(5, 2) NOT NULL,
    IsPregnant BIT NOT NULL,
    LastVetCheck DATE NOT NULL
);
GO

INSERT INTO Chicken(Name, Breed, Age, EggProduction, IsPregnant, LastVetCheck)
VALUES
('Clucky', 'Leghorn', 2, 5.5, 0, '2024-01-15'),
('Feathers', 'Rhode Island Red', 3, 4.0, 1, '2024-02-20'),
('Pecky', 'Plymouth Rock', 1, 6.0, 0, '2024-03-10');
GO
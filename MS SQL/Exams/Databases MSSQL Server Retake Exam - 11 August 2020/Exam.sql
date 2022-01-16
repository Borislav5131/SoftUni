CREATE DATABASE Bakery

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR(1) CHECK(Gender IN ('M','F')) NOT NULL,
	Age INT NOT NULL,
	PhoneNumber VARCHAR(10) CHECK(LEN(PhoneNumber) = 10) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX) NOT NULL,
	Price DECIMAL(18,2) NOT NULL CHECK(Price >= 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(250),
	Rate DECIMAL(18,2) NOT NULL CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE NOT NULL,
	AddressText NVARCHAR(30) NOT NULL,
	Summary NVARCHAR(200),
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	Description NVARCHAR(200),
	OriginCountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT NOT NULL FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT NOT NULL FOREIGN KEY REFERENCES Ingredients(Id),
	PRIMARY KEY(ProductId,IngredientId)
)

-----------------------------------

INSERT INTO Distributors(Name,CountryId,AddressText,Summary) VALUES
('Deloitte & Touche',	2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',	13,	'58 Hancock St',	'Customer loyalty'),
('Kitchen People',	1,	'3 E 31st St #77'	,'Triple-buffered stable delivery'),
('General Color Co Inc',	21,	'6185 Bohn St #72',	'Focus group'),
('Beck Corporation',	23,	'21 E 64th Ave',	'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName,LastName,Age,Gender,PhoneNumber,CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

---------------------------------------------

UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN('Bay Leaf','Paprika','Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

------------------------------------------

DELETE FROM Feedbacks 
WHERE CustomerId = 14 OR ProductId = 5

----------------------------------------

SELECT Name	
	  ,Price
	  ,Description
FROM Products
ORDER BY Price DESC,Name ASC

----------------------------------------

SELECT ProductId
	  ,Rate
	  ,Description
	  ,CustomerId
	  ,Age
	  ,Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY ProductId DESC,Rate

----------------------------------

SELECT CONCAT(FirstName,' ',LastName) AS CustomerName
	  ,PhoneNumber
	  ,Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id

-----------------------------------

SELECT FirstName,Age,PhoneNumber 
FROM Customers AS cu
JOIN Countries AS co ON cu.CountryId = co.Id
WHERE Age >= 21 AND FirstName LIKE '%an%' OR PhoneNumber LIKE '%38' AND co.Name <> 'Greece'
ORDER BY FirstName,Age DESC

--------------------------------------

SELECT * 
FROM(
	SELECT d.Name AS DistributorName
		  ,i.Name AS IngredientName
		  ,p.Name AS ProductName
		  ,AVG(f.Rate) AS AverageRate
	FROM Distributors AS d
	JOIN Ingredients AS i ON d.Id = i.DistributorId
	JOIN ProductsIngredients AS pi ON i.Id = pi.IngredientId
	JOIN Products AS p ON pi.ProductId = p.Id
	JOIN Feedbacks AS f ON p.Id = f.ProductId
	GROUP BY d.Name,i.Name,p.Name ) AS Rank
WHERE AverageRate BETWEEN 5.0 AND 8.0
ORDER BY DistributorName,IngredientName,ProductName
	
-------------------------------------

SELECT CountryName,DisributorName
FROM (
	SELECT c.Name AS CountryName
		  ,d.Name AS DisributorName
		  ,DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.id) DESC) AS Rank
	FROM Countries AS c
	JOIN Distributors AS d ON c.Id = d.CountryId
	LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
	GROUP BY c.Name,d.Name
	) AS SubQue
WHERE Rank = 1
ORDER BY CountryName,DisributorName

------------------------------------

GO

CREATE VIEW v_UserWithCountries 
AS
	SELECT CONCAT(c.FirstName,' ',c.LastName) AS CustomerName 
		  ,c.Age
		  ,c.Gender
		  ,co.Name AS CountryName
	FROM Customers AS c
	JOIN Countries AS co ON c.CountryId = co.Id

GO

-----------------------------------

CREATE TRIGGER dbo.DeleteTR(@InputId INT)
ON PRODUCTS
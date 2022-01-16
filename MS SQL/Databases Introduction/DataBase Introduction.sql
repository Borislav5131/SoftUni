CREATE DATABASE Minions  --Създаване на база данни. 

USE Minions  -- Използване на базата данни.

CREATE TABLE [Minions]    --Създаване на таблица.
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT
) 

ALTER TABLE [Minions]  --Alter -> промяна на структурата на таблицата.
ADD CONSTRAINT PK_MinionsId PRIMARY KEY (Id) -- Добавяне на constraint.

DROP TABLE [Minions] --Изтриване на таблица.

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY NOT NULL, --Автоматично я прави PK.
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE [Minions]  --Добавяне на нова колона.
ADD [TownId] INT

ALTER TABLE [Minions] --Добавяне на constraint FK.
ADD CONSTRAINT FK_MinionsTownId FOREIGN KEY (TownId) REFERENCES [Towns]([Id])

INSERT INTO [Towns] ([Id],[Name]) VALUES --Добавяне на стойност.
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id],[Name],[Age],[TownId]) VALUES
(1,'Kevin',22,1),
(2,'Bob', 15,3),
(3,'Steward',null,2)

TRUNCATE TABLE [Minions] --Изпразване на таблица.

CREATE TABLE [People]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Picture],[Height],[Weight],[Gender],[Birthdate],[Biography]) VALUES
('Pesho',(CAST('wahid' AS VARBINARY(MAX))),10,50,'m','10-06-2002','Hello'),
('Pesho',(CAST('wahid' AS VARBINARY(MAX))),10,50,'m','10-06-2002','Hello'),
('Pesho',(CAST('wahid' AS VARBINARY(MAX))),10,50,'m','10-06-2002','Hello'),
('Pesho',(CAST('wahid' AS VARBINARY(MAX))),10,50,'m','10-06-2002','Hello'),
('Pesho',(CAST('wahid' AS VARBINARY(MAX))),10,50,'m','10-06-2002','Hello')

CREATE TABLE [Users]
(
	[Id] INT IDENTITY,
	[Username] NCHAR(30) PRIMARY KEY NOT NULL,
	[Password] NCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5) NOT NULL
)

INSERT INTO [Users] ([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted]) VALUES
('Pesho','hiadna',(CAST('wahid' AS VARBINARY(MAX))),'10-06-5555','true'),
('Pesh','hiadna',(CAST('wahid' AS VARBINARY(MAX))),'10-06-5555','true'),
('Pes','hiadna',(CAST('wahid' AS VARBINARY(MAX))),'10-06-5555','true'),
('Pe','hiadna',(CAST('wahid' AS VARBINARY(MAX))),'10-06-5555','true'),
('P','hiadna',(CAST('wahid' AS VARBINARY(MAX))),'10-06-5555','true')


-------------------------------

CREATE DATABASE [Movies]

Use Movies

CREATE TABLE [Directors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(30) NOT NULL,
	[DirectorId] INT,
	[CopyrightYear] CHAR(4),
	[Length] INT,
	[GenreId] INT,
	[CategoryId] INT,
	[Rating] NVARCHAR(100),
	[Notes] NVARCHAR(MAX),
	FOREIGN KEY (DirectorId) REFERENCES [Directors](Id),
	FOREIGN KEY (GenreId) REFERENCES [Genres](Id),
	FOREIGN KEY (CategoryId) REFERENCES [Categories](Id)
)

INSERT INTO [Directors] ([DirectorName],[Notes]) VALUES
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg')

INSERT INTO [Genres] ([GenreName],[Notes]) VALUES
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg')

INSERT INTO [Categories] ([CategoryName],[Notes]) VALUES
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg'),
('Pesho','gg')

INSERT INTO [Movies] ([Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating],[Notes]) VALUES
('gg',5,'2020',5,2,3,'good','skcjsjc'),
('gg',5,'2020',5,2,3,'good','skcjsjc'),
('gg',5,'2020',5,2,3,'good','skcjsjc'),
('gg',5,'2020',5,2,3,'good','skcjsjc'),
('gg',5,'2020',5,2,3,'good','skcjsjc')

-------------------------------------

CREATE DATABASE CarRental 

CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] INT,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
)

CREATE TABLE Cars
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(10) NOT NULL,
	[Model] NVARCHAR(10) NOT NULL,
	[CarYear] INT,
	[CategoryId] INT,
	[Doors] INT,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(30),
	[Available] NVARCHAR(30),
	FOREIGN KEY (CategoryId) REFERENCES [Categories](Id)
)

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50),
	[Notes] NVARCHAR(100)
)

CREATE TABLE Customers 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(30),
	[City] NVARCHAR(20),
	[ZIPCode] NVARCHAR(10),
	[Notes] NVARCHAR(100)
)

CREATE TABLE RentalOrders
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CarId] INT NOT NULL,
	[TankLevel] INT,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] INT,
	[RateApplied] INT,
	[TaxRate] INT,
	[OrderStatus] NVARCHAR(30),
	[Notes] NVARCHAR(100),
	FOREIGN KEY ([EmployeeId]) REFERENCES Employees(Id),
	FOREIGN KEY ([CustomerId]) REFERENCES Customers(Id),
	FOREIGN KEY ([CarId]) REFERENCES Cars(Id)
)

INSERT INTO Categories([CategoryName]) VALUES
	('Седан'),
	('Купе'),
	('Комби')

INSERT INTO Cars ([PlateNumber],[Manufacturer],[Model],[CategoryId]) VALUES
	(5131,'BMW','E90',1),
	(4626,'Opel','Astra',2),
	(9531,'Audi','A3',3)

INSERT INTO Employees([FirstName],[LastName]) VALUES
	('Gosho','Todorov'),
	('Gosho','Todorov'),
	('Gosho','Todorov')

INSERT INTO Customers (DriverLicenceNumber,FullName) VALUES	
	(5555,'Gosho Todorov'),
	(5555,'Gosho Todorov'),
	(5555,'Gosho Todorov')

INSERT INTO RentalOrders ([EmployeeId],[CustomerId],[CarId]) VALUES
	(1,2,3),
	(2,3,1),
	(3,2,1)

--------------------------------------------

CREATE DATABASE Hotel

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50),
	[Notes] NVARCHAR(100)
)

CREATE TABLE Customers
(
	[AccountNumber] INT PRIMARY KEY NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] INT,
	[EmergencyName] NVARCHAR(50),
	[EmergencyNumber] INT,
	[Notes] NVARCHAR(100)
)

CREATE TABLE RoomStatus
(
	[RoomStatus] NVARCHAR(10) PRIMARY KEY,
	[Notes] NVARCHAR(100)
)

CREATE TABLE RoomTypes 
(
	[RoomType] NVARCHAR(10) PRIMARY KEY,
	[Notes] NVARCHAR(100)
)

CREATE TABLE BedTypes 
(
	[BedType] NVARCHAR(10) PRIMARY KEY,
	[Notes] NVARCHAR(100)
)

CREATE TABLE Rooms
(
	[RoomNumber] INT PRIMARY KEY NOT NULL,
	[RoomType] NVARCHAR(10),
	[BedType] NVARCHAR(10),
	[Rate] NVARCHAR(100),
	[RoomStatus] NVARCHAR(10),
	[Notes] NVARCHAR(100),
	FOREIGN KEY ([RoomType]) REFERENCES RoomTypes(RoomType),
	FOREIGN KEY ([BedType]) REFERENCES BedTypes(BedType),
	FOREIGN KEY ([RoomStatus]) REFERENCES RoomStatus(RoomStatus)
)

CREATE TABLE Payments
(
	[Id] INT PRIMARY KEY ,
	[EmployeeId] INT NOT NULL,
	[PaymentDate] DATETIME2,
	[AccountNumber] INT,
	[FirstDateOccupied] DATETIME2,
	[LastDateOccupied] DATETIME2,
	[TotalDays] INT,
	[AmountCharged] DECIMAL,
	[TaxRate] INT,
	[TaxAmount] INT,
	[PaymentTotal] DECIMAL,
	[Notes] NVARCHAR(100),
	FOREIGN KEY ([EmployeeId]) REFERENCES Employees(Id)
)	

CREATE TABLE Occupancies
(
	[Id] INT PRIMARY KEY ,
	[EmployeeId] INT,
	[DateOccupied] DATETIME2,
	[AccountNumber] INT NOT NULL,
	[RoomNumber] INT,
	[RateApplied] NVARCHAR(20),
	[PhoneCharge] NVARCHAR(20),
	[Notes] NVARCHAR(100),
	FOREIGN KEY ([EmployeeId]) REFERENCES Employees(Id),
	FOREIGN KEY ([RoomNumber]) REFERENCES Rooms(RoomNUmber)
)

INSERT INTO Employees (FirstName,LastName) VALUES
	('Gosho','Todorov'),
	('Gosho','Todorov'),
	('Gosho','Todorov')

INSERT INTO Customers (AccountNumber,FirstName,LastName) VALUES
	(5,'Gosho','Todorov'),
	(3,'Gosho','Todorov'),
	(4,'Gosho','Todorov')

INSERT INTO RoomStatus (RoomStatus) VALUES
	('g'),
	('t'),
	('j')

INSERT INTO RoomTypes (RoomType) VALUES
	('h'),
	('d'),
	('n')

INSERT INTO BedTypes (BedType) VALUES
	('o'),
	('v'),
	('n')

INSERT INTO Rooms (RoomNumber) VALUES
	(1),
	(2),
	(3)

INSERT INTO Payments (Id,EmployeeId) VALUES
	(1,2),
	(2,3),
	(3,1)

INSERT INTO Occupancies (Id,EmployeeId,AccountNumber,RoomNumber) VALUES
	(1,2,10,1),
	(2,3,11,3),
	(3,1,15,2)

---------------------------------
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30)
)

INSERT INTO Towns(Name) VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

CREATE TABLE Addresses
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(50),
	[TownId] INT NOT NULL,
	FOREIGN KEY (TownId) REFERENCES Towns(Id)
)

INSERT INTO Addresses(TownId) VALUES
	(1),
	(2),
	(3),
	(2)

CREATE TABLE Departments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30)
)

INSERT INTO Departments(Name) VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30),
	[MiddleName] NVARCHAR(30),
	[LastName] NVARCHAR(30),
	[JobTitle] NVARCHAR(30),
	[DepartmentId] INT,
	[HireDate] DATETIME2,
	[Salary] DECIMAL(10,2),
	[AddressId] INT,
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
	FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

INSERT INTO Employees([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary]) VALUES
	('Ivan', 'Ivanov','Ivanov','.NET Developer',4,GetDate(),3500),
	('Petar','Petrov','Petrov','Senior Engineer',1,GetDate(),4000),
	('Maria','Petrova','Ivanova','Intern',5,GetDate(),525.25),
	('Georgi','Teziev','Ivanov','CEO',2,GetDate(),3000),
	('Peter','Pan','Pan','Intern',3,GetDate(),599.88)


SELECT [Name] FROM Towns
 ORDER BY [Name]
SELECT [Name] FROM Departments
 ORDER BY [Name]
SELECT [FirstName],[LastName],[JobTitle],[Salary] FROM Employees
ORDER BY [Salary] Desc

UPDATE Employees
SET [Salary] = [Salary] + ([Salary] * 10.00 / 100.0)

SELECT [Salary] FROM Employees

UPDATE Payments
SET [TaxRate] = [TaxRate] - ([TaxRate] * 0.03)

SELECT [TaxRate] FROM Payments

DELETE FROM Occupancies
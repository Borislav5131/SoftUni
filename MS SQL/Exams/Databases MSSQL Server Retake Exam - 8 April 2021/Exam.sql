CREATE DATABASE Service

CREATE TABLE Users
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	[Birthdate] DATETIME,
	[Age] INT CHECK(Age >= 14 AND Age <= 110),
	[Email] NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25),
	[LastName] NVARCHAR(25),
	[Birthdate] DATETIME,
	[Age] INT CHECK(Age >= 18 AND Age <= 110),
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	[Id]INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(30) NOT NULL 
)

CREATE TABLE Reports
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	[StatusId] INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	[OpenDate] DATETIME NOT NULL,
	[CloseDate] DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES Users(Id),
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id)
)

------------------------------------------------------

INSERT INTO Employees (FirstName,LastName,Birthdate,DepartmentId) VALUES
	('Marlo','O''Malley','1958-9-21',1),
	('Niki','Stanaghan','1969-11-26',4),
	('Ayrton','Senna','1960-3-21',9),
	('Ronnie','Peterson','1944-2-14',9),
	('Giovanna','Amati','1959-7-20',5)

INSERT INTO Reports (CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(1,	1,	'2017-4-13',NULL,'Stuck Road on Str.133',	6,	2),
(6,	3,	'2015-9-05','2015-12-06','Charity trail running',	3,	5),
(14,2,	'2015-9-07',NULL,'Falling bricks on Str.58',	5,	2),
(4,	3,	'2017-7-03','2017-7-06','Cut off streetlight on Str.11',	1,	1)

------------------------------------------------------

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-------------------------------------------------------

DELETE FROM Reports 
WHERE StatusId = 4

--------------------------------------------------------

SELECT Description
	  ,FORMAT(OpenDate,'dd-MM-yyyy')
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC

--------------------------------------------------------

SELECT r.Description, c.Name AS CategoryName
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE r.CategoryId IS NOT NULL
ORDER BY r.Description,c.Name

--------------------------------------------------------

SELECT TOP(5) c.Name
	  ,COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, Name ASC

---------------------------------------------------------

SELECT u.Username
	  ,c.Name AS CategoryName
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
RIGHT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DAY(r.OpenDate) = DAY(u.Birthdate) AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY Username ASC, CategoryName ASC

----------------------------------------------------------

SELECT CONCAT(e.FirstName,' ',e.LastName) AS FullName
	  ,COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY CONCAT(e.FirstName,' ',e.LastName)
ORDER BY UsersCount DESC,FullName ASC

------------------------------------------------------------

SELECT ISNULL(e.FirstName+' '+e.LastName,'None') AS Employee
	  ,ISNULL(d.Name,'None') AS Department
	  ,ISNULL(c.Name,'None') AS Category
	  ,ISNULL(r.Description,'None')
	  ,ISNULL(FORMAT(r.OpenDate,'dd.MM.yyyy'),'None') AS OpenDate
	  ,ISNULL(s.Label,'None') AS Status
	  ,ISNULL(u.Name,'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN Status AS s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.Description, OpenDate, s.Label, u.Name

-------------------------------------------------------------

GO

CREATE FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT AS
BEGIN

	DECLARE @Hours INT

	IF @StartDate IS NULL OR @EndDate IS NULL
		BEGIN
			SET @Hours = 0
		END
	ELSE
		BEGIN
			SET @Hours = DATEDIFF(HOUR,@StartDate,@EndDate)
		END	

	RETURN @Hours
END

GO

----------------------------------------------------------------
GO

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN	
	DECLARE @EmplayeeDepartmentId INT
	DECLARE @CategoryDepartmentId INT

	SET @EmplayeeDepartmentId = (SELECT d.Name
								FROM Employees AS e
								JOIN Departments AS d ON e.DepartmentId = d.Id
								WHERE e.Id = @EmployeeId)

	SET @CategoryDepartmentId = (SELECT d.Name
								FROM Reports AS r
								JOIN Categories AS c ON r.CategoryId = c.Id
								JOIN Departments AS d ON d.id = c.DepartmentId
								WHERE r.Id = @ReportId )

	IF(@EmplayeeDepartmentId != @CategoryDepartmentId)
		BEGIN 
			;THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
		END

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId;

END

GO

DROP PROCEDURE usp_AssignEmployeeToReport
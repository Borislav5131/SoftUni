SELECT FirstName,LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

--------------------------------

SELECT FirstName,LastName
FROM Employees
WHERE LastName LIKE '%ei%'

---------------------------------

SELECT FirstName
From Employees
Where DepartmentID IN (3,10)
AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

---------------------------------

SELECT FirstName,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%' 

----------------------------------

SELECT Name
FROM Towns
WHERE DATALENGTH(Name) IN (5,6)
ORDER BY NAME ASC

-----------------------------------

SELECT TownID,Name
FROM Towns
WHERE NAME LIKE 'M%'
OR NAME LIKE 'K%'
OR NAME LIKE 'B%'
OR NAME LIKE 'E%'
ORDER BY NAME ASC

-----------------------------------

SELECT TownID,Name
FROM Towns
WHERE NAME NOT LIKE 'R%'
AND NAME NOT LIKE 'B%'
AND NAME NOT LIKE 'D%'
ORDER BY NAME ASC

-------------------------------------

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName
FROM Employees
WHERE DATEPART(YEAR,HireDate) > 2000

---------------------------------------

SELECT FirstName,LastName
FROM Employees
WHERE DATALENGTH(LastName) = 5

----------------------------------------

SELECT EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER (PARTITION BY SALARY ORDER BY EmployeeID) Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-----------------------------------------

SELECT * 
FROM
(
	SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER (PARTITION BY SALARY ORDER BY EmployeeID) [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
) a
WHERE a.[Rank] = 2
ORDER BY Salary DESC

-----------------------------------------

SELECT CountryName, IsoCode
FROM Countries
WHERE DATALENGTH(CountryName) - DATALENGTH(REPLACE(CountryName,'A','')) >= 3
ORDER BY IsoCode

------------------------------------------
--13
SELECT PeakName
	,RiverName
	,CONCAT (LOWER(LEFT(PeakName,LEN(PeakName) - 1)),LOWER(RiverName)) AS Mix
FROM Peaks,Rivers
WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
ORDER BY Mix

---------------------------------------------

SELECT TOP(50) Name,
FORMAT (Start,'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start], [Name]

---------------------------------------------

SELECT Username,
	SUBSTRING(Email,CHARINDEX('@',Email) + 1,LEN(Email) - CHARINDEX('@',Email) + 1) AS EmailProvider
FROM Users
ORDER BY EmailProvider,Username

----------------------------------------------

SELECT Username,IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

----------------------------------------------

SELECT [Name] AS Game
	,CASE
		WHEN DATEPART(hh,[Start]) >= 0 AND DATEPART(hh,[Start]) < 12 THEN 'Morning'
		WHEN DATEPART(hh,[Start]) >= 12 AND DATEPART(hh,[Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(hh,[Start]) >= 18 AND DATEPART(hh,[Start]) < 24 THEN 'Evening '
	END AS [Part Of The Day]
	,CASE
		WHEN Duration <=3 THEN 'Extra Short'
		WHEN Duration >=4 AND Duration <=6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY Game,Duration,[Part Of The Day]

----------------------------------------------

SELECT   ProductName
		,OrderDate
		,DATEADD(DAY,3,OrderDate) AS PayDue
		,DATEADD(MONTH,1,OrderDate) AS DeliverDue
FROM Orders		
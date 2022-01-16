CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	(
		SELECT FirstName, LastName
		FROM Employees
		WHERE Salary > 35000
	)

-------------------------------------------------
GO 

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS
	(
		SELECT FirstName, LastName
		FROM Employees
		WHERE Salary >= @Number
	)

--------------------------------------------------

GO 

CREATE PROCEDURE usp_GetTownsStartingWith(@String NVARCHAR(50))
AS 
	(
		SELECT [Name]
		FROM Towns
		WHERE LEFT([Name],LEN(@String)) = @String
	)

---------------------------------------------------

GO

CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(50))
AS
	(
		SELECT FirstName, LastName
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		LEFT JOIN Towns AS t ON a.TownID = t.TownID
		WHERE t.Name = @TownName
	)

-----------------------------------------------------

GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(7)
AS
BEGIN 
	
	DECLARE @Result VARCHAR(7)

	IF @salary < 30000
		SET @Result = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
		SET @Result = 'Average'
	ELSE
		SET @Result = 'High'

	RETURN @Result
END

GO

------------------------------------------------------

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@Level VARCHAR(7))
AS
	(
		SELECT FirstName, LastName
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level
	)

------------------------------------------------------

GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	 DECLARE @index INT = 1
     DECLARE @length INT = LEN(@word)
     DECLARE @letter CHAR(1)

     WHILE (@index <= @length)
     BEGIN
          SET @letter = SUBSTRING(@word, @index, 1)
          IF (CHARINDEX(@letter, @setOfLetters) > 0)
             SET @index = @index + 1
          ELSE
             RETURN 0
     END
     RETURN 1
END

GO

--------------------------------------------------------

GO

CREATE PROC usp_GetHoldersFullName 
AS 
	SELECT CONCAT(FirstName,' ',LastName) AS [Full Name]
	FROM AccountHolders

---------------------------------------------------

GO 

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Num MONEY)
AS
	SELECT FirstName AS [First Name]
		  ,LastName AS [Last Name]
	FROM AccountHolders AS ac
	JOIN Accounts AS a ON a.AccountHolderId = ac.Id
	GROUP BY FirstName,LastName
	HAVING SUM(a.Balance) > @Num
	ORDER BY FirstName, LastName

-------------------------------------------

GO

CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18,2),@Interest Float,@Years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @Result DECIMAL(18,4) 
	SET @Result = @Sum * POWER((1+@Interest),@Years)
	RETURN @Result
END

GO

--------------------------------

GO

CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
	DECLARE @Sum DECIMAL(18,2) = (SELECT Balance
								FROM Accounts
								WHERE Id = @AccountId)

	DECLARE @Years INT = 5
	
	SELECT a.Id AS [Account Id]
		  ,ah.FirstName AS [First Name]
		  ,ah.LastName AS [Last Name]
		  ,a.Balance AS [Current Balance]
		  ,(dbo.ufn_CalculateFutureValue(@Sum,@InterestRate,@Years)) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId

GO

-------------------------

GO
	
GO
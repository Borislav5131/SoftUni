SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits

----------------------------

SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

----------------------------

SELECT DepositGroup
	  ,MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

-----------------------------

SELECT TOP(2) DepositGroup
FROM(
	SELECT DepositGroup
		  ,AVG(MagicWandSize) AS MinWandSize
	FROM WizzardDeposits
	GROUP BY DepositGroup
	) AS DepositGroupMinSize
ORDER BY MinWandSize 

-------------------------------

SELECT DepositGroup
	  ,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

-------------------------------

SELECT DepositGroup
	  ,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

---------------------------------

SELECT DepositGroup
	  ,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

----------------------------------

SELECT DepositGroup
	  ,MagicWandCreator
	  ,MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-----------------------------------

SELECT AgeGroup
	  ,COUNT(Id)
FROM (
	SELECT *
		  ,CASE
			WHEN Age >=10 AND Age <=10 THEN '[0-10]'
			WHEN Age >=11 AND Age <= 20 THEN '[11-20]'
			WHEN Age >=21 AND Age <= 30 THEN '[21-30]'
			WHEN Age >=31 AND Age <= 40 THEN '[31-40]'
			WHEN Age >=41 AND Age <= 50 THEN '[41-50]'
			WHEN Age >=51 AND Age <= 60 THEN '[51-60]'
			WHEN Age >=61 THEN '[61+]'
		  END AS AgeGroup
	FROM WizzardDeposits
	) AS WizzartDepositsAgeGroups
GROUP BY AgeGroup

--------------------------------------

SELECT DISTINCT LEFT(FirstName,1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter

--------------------------------------

SELECT DepositGroup
	  ,IsDepositExpired
	  ,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

----------------------------------------

SELECT SUM([Difference])
FROM (
	SELECT *
		,[Host Wizard Deposit] - [Guest Wizard Deposit] AS [Difference]
	FROM (
		SELECT FirstName AS Host 
				,DepositAmount AS [Host Wizard Deposit]
				,LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard]
				,LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit]
		FROM WizzardDeposits
		) AS WizardInfoLead 
	) AS SubQue


------------------------------------------

SELECT DepartmentID, SUM(Salary)
FROM Employees 
GROUP BY DepartmentID

-------------------------------------------

SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE HireDate > '01-01-2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2,5,7)

--------------------------------------------

SELECT * INTO EmployeesCopy
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesCopy
WHERE ManagerID = 42

UPDATE EmployeesCopy
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesCopy
GROUP BY DepartmentID

----------------------------------------------

SELECT *
FROM (
	SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	) AS SubQue
WHERE MaxSalary NOT BETWEEN 30000 AND 70000

-----------------------------------------------

SELECT COUNT(Salary) AS Count
FROM Employees
WHERE ManagerID IS NULL

------------------------------------------------

SELECT DepartmentID, Salary AS ThirdHighestSalary
FROM (
	SELECT DepartmentID
		  ,Salary
		  , DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
	FROM Employees
	) AS SubQue
WHERE Rank = 3
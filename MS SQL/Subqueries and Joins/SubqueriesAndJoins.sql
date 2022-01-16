SELECT TOP(5) e.EmployeeID
	,e.JobTitle
	,a.AddressID
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a 
ON e.AddressID = a.AddressID
ORDER BY a.AddressID ASC

-------------------------------

SELECT TOP(50) e.FirstName
		,e.LastName
		,t.[Name] AS Town
		,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY e.FirstName ASC, e.LastName ASC

--------------------------------

SELECT e.EmployeeID
	,e.FirstName
	,e.LastName
	,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

---------------------------------

SELECT TOP (5) e.EmployeeID
	  ,e.FirstName
	  ,e.Salary
	  ,d.[Name] AS DeparmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC

-----------------------------------


SELECT TOP(3) e.EmployeeID
	   ,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

-------------------------------------

SELECT e.FirstName
	   ,e.LastName
	   ,e.HireDate
	   ,d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1/1/1999' AND d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate

--------------------------------------

SELECT TOP(5) e.EmployeeID
	,e.FirstName
	,p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002/08/13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

----------------------------------------

SELECT   e.EmployeeID
		,e.FirstName
		,CASE
			WHEN DATEPART(YEAR,p.StartDate) >= 2005 THEN NULL
			ELSE p.[Name]
			END
		AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

------------------------------------------

SELECT   e1.EmployeeID
		,e1.FirstName
		,e1.ManagerID
		,e2.FirstName AS ManagerName
FROM Employees AS e1
JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
WHERE e1.ManagerID IN(3,7)
ORDER BY e1.EmployeeID

--------------------------------------------

SELECT TOP(50)   e1.EmployeeID
				,CONCAT(e1.FirstName,' ',e1.LastName) AS EmplyeeName
				,CONCAT(e2.FirstName,' ',e2.LastName) AS ManagerName
				,d.[Name] AS DepartmentName
FROM Employees AS e1
JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
JOIN Departments AS d ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID

---------------------------------------------

SELECT MIN(AvgSalary) AS MinAvgSalary
FROM 
(	SELECT AVG(e.Salary) AS AvgSalary
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	GROUP BY e.DepartmentID
) AS AvgSalaryTable

----------------------------------------------

SELECT   c.CountryCode
		,m.MountainRange
		,p.PeakName
		,p.Elevation
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-------------------------------------------------

SELECT   mc.CountryCode
		,COUNT(mc.CountryCode) AS MountainRanges
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryName IN('United States','Russia','Bulgaria')
GROUP BY mc.CountryCode

--------------------------------------------------

SELECT TOP(5) c.CountryName
			,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName ASC

---------------------------------------------------

SELECT   ContinentCode
		,CurrencyCode
		,CurrencyCount AS CurrencyUsage
FROM
	(
		SELECT *
			,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
		FROM
		(
			SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyCount
			FROM Countries
			GROUP BY ContinentCode, CurrencyCode
		) AS [Table]
		WHERE CurrencyCount > 1
	) AS [Table2]
WHERE CurrencyRank = 1
ORDER BY ContinentCode

----------------------------------------------------

SELECT COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE m.Id IS NULL

-----------------------------------------------------

SELECT TOP(5) CountryName
	  ,MAX(p.Elevation) AS HighestPeakElevation
	  ,MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

-------------------------------------------------------

SELECT TOP(5) CountriesInfo.Country AS Country
			 ,ISNULL(CountriesInfo.PeakName, 'no highest peak') AS HighestPeakName
			 ,ISNULL(CountriesInfo.Elevation, 0) AS HighestPeakElevation
			 ,CASE 
				WHEN CountriesInfo.Country IS NOT NULL
					THEN CountriesInfo.MountainRange
				ELSE 'no mountain' END AS Mountain
FROM (
		SELECT   c.CountryName AS Country
				,p.PeakName
				,p.Elevation
				,m.MountainRange
				,ROW_NUMBER() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS rn
		FROM Countries AS c 
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	) AS CountriesInfo
WHERE CountriesInfo.rn = 1
ORDER BY Country,HighestPeakName
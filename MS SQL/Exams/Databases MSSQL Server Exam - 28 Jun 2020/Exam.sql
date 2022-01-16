CREATE DATABASE ColonialJourney

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT(0)
)

CREATE TABLE Colonists
(	
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(	
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
	SpaceshipId INT NOT NULL FOREIGN  KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) UNIQUE CHECK(LEN(CardNumber) = 10) NOT NULL,
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN('Pilot','Engineer','Trooper','Cleaner','Cook')),
	ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)

------------------------------------

INSERT INTO Planets (Name) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships (Name,Manufacturer,LightSpeedRate) VALUES
('Golf',	'VW',	3),
('WakaWaka',	'Wakanda',	4),
('Falcon9'	,'SpaceX',	1),
('Bed'	,'Vidolov',	6)

----------------------------------------

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

 ---------------------------------------

DELETE FROM TravelCards
WHERE JourneyId IN (1,2,3)

DELETE FROM Journeys
WHERE Id IN (1,2,3)

------------------------------------------

SELECT Id
	  ,FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart
	  ,FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--------------------------------------------

SELECT c.Id
	  ,CONCAT(FirstName,' ',LastName) AS FullName
FROM Colonists AS c
LEFT JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

--------------------------------------------

SELECT COUNT(c.Id) AS [count]
FROM Colonists AS c
LEFT JOIN TravelCards AS tc ON c.Id = tc.ColonistId
LEFT JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

-----------------------------------------------

SELECT s.Name	
	  ,s.Manufacturer
FROM Spaceships AS s
LEFT JOIN Journeys AS j ON s.Id = j.SpaceshipId
LEFT JOIN TravelCards AS tc ON j.Id = tc.JourneyId
LEFT JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE DATEDIFF(year,c.BirthDate,'01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot'
GROUP BY s.Name, s.Manufacturer
ORDER BY s.Name

------------------------------------------------------

SELECT p.Name AS PlanetName
	  ,COUNT(j.Id) AS JourneysCount
FROM Planets AS p
 JOIN Spaceports AS s ON s.PlanetId = p.Id
 JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC,PlanetName

--------------------------------------------------------

SELECT *
FROM (
	SELECT tc.JobDuringJourney
		  ,CONCAT(c.FirstName,' ',c.LastName) AS FullName
		  ,RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS Rank
	FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	) AS SubQue
WHERE Rank = 2

---------------------------------------------------------------

GO

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN

	RETURN (SELECT COUNT(ColonistId)
	FROM Planets AS p
	JOIN Spaceports AS sp ON sp.PlanetId = p.id
	JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
	JOIN TravelCards AS tc ON tc.JourneyId = j.Id
	WHERE p.Name = @PlanetName)

END

---------------------------------------------------------------

GO

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose varchar(11))
AS
	
		IF (SELECT Id FROM Journeys WHERE Journeys.Id = @JourneyId) IS NULL
			THROW 51000, 'The journey does not exist!', 1;
		ELSE IF (SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose
			THROW 51000, 'You cannot change the purpose!', 1;
		ELSE
			UPDATE Journeys SET Purpose = @NewPurpose WHERE Id = @JourneyId



EXEC usp_ChangeJourneyPurpose 4, 'Technical'	
EXEC usp_ChangeJourneyPurpose 2, 'Educational'	
EXEC usp_ChangeJourneyPurpose 196, 'Technical'	

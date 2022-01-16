CREATE DATABASE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode NVARCHAR(2) NOT NULL 
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT NOT NULL CHECK(Luggage >= 0)
	PRIMARY KEY(AccountId,TripId)
)

---------------------------------------

INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email) VALUES
('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL,	'Petrov',	11	,'1978-05-16'	,'g_petrov@gmail.com'),
('Ivan'	,'Petrovich',	'Pavlov',	59,	'1849-09-26'	,'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm'	,'Nietzsche',	2	,'1844-10-15'	,'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId,BookDate,ArrivalDate,ReturnDate,CancelDate) VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29', NULL)

-----------------------------------

UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN(5,7,9)

--------------------------------------

DELETE FROM AccountsTrips
WHERE AccountId = 47

-------------------------------------

SELECT FirstName
	  ,LastName
	  ,FORMAT(BirthDate,'MM-dd-yyyy')
	  ,c.Name AS Hometown
	  ,Email
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY Hometown

----------------------------------

SELECT c.Name AS City
	  ,COUNT(h.Id) AS Hotel
FROM Hotels AS h
JOIN Cities As c ON h.CityId = c.Id
WHERE h.CityId IS NOT NULL
GROUP BY c.Name
ORDER BY Hotel DESC, City ASC

------------------------------------

SELECT Id
	  ,FullName
	  ,MAX(DaysLong) AS LongestTrip
	  ,MIN(DaysLong) AS ShortestTrip
FROM (
	SELECT a.Id
		  ,CONCAT(a.FirstName,' ',a.LastName) AS FullName
		  ,DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate) AS DaysLong
	FROM Accounts AS a
	JOIN AccountsTrips AS at ON at.AccountId = a.Id
	JOIN Trips AS t ON at.TripId = t.Id
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL 
	) AS [Subque]
GROUP BY Id, FullName
ORDER BY LongestTrip DESC, ShortestTrip ASC

--------------------------------------

SELECT TOP(10) c.Id
	  ,c.Name AS City
	  ,c.CountryCode AS Country
	  ,COUNT(a.Id) AS Accounts
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
GROUP BY c.Id,c.Name,c.CountryCode
ORDER BY Accounts DESC

-----------------------------------

SELECT Id
	  ,Email
	  ,City
	  ,COUNT(Rank) AS Trips
FROM (
	SELECT a.Id	
		  ,a.Email
		  ,c.Name AS City
		  ,DENSE_RANK() OVER (PARTITION BY t.Id ORDER BY a.Id) AS Rank
	FROM Accounts AS a
	JOIN Cities AS c ON a.CityId = c.Id
	JOIN AccountsTrips AS at ON at.AccountId = a.id
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	WHERE h.CityId = a.CityId
	) AS SubQue2
GROUP BY Id,Email,City
ORDER BY Trips DESC,Id

------------------------------------

SELECT t.Id
	  , CASE
			WHEN a.MiddleName IS NULL THEN CONCAT(a.FirstName,' ',a.LastName)
			ELSE CONCAT(a.FirstName,' ',MiddleName,' ',LastName) 
		END AS FullName
	  ,(SELECT [Name] FROM Cities WHERE Id = a.CityId) AS [From]
	  ,c.Name AS [To]
	  , CASE
			WHEN CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONCAT(DATEDIFF(DAY,ArrivalDate,ReturnDate), ' ','days')
		END AS Duration
FROM Trips AS t
JOIN AccountsTrips AS at ON at.TripId = t.Id
JOIN Accounts AS a ON at.AccountId = a.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON c.id = h.CityId
ORDER BY FullName, t.Id

----------------------------------

GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
		DECLARE @Room INT = 
			(SELECT TOP(1) r.Id
			FROM Hotels AS h
			JOIN Rooms AS r ON r.HotelId = h.Id
			JOIN Trips AS t ON t.RoomId = r.Id
			WHERE h.Id = @HotelId
				AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
				AND t.CancelDate IS NULL
				AND r.Beds >= @People
				AND YEAR(@Date) = YEAR(t.ArrivalDate)
			ORDER BY r.Price DESC)

		IF(@Room IS NULL)
			RETURN 'No rooms available'
		ELSE
			DECLARE @RoomPrice DECIMAL(18,2) = (SELECT Price FROM Rooms WHERE Id = @Room)

			DECLARE @RoomType VARCHAR (50)  = (SELECT [Type] FROM Rooms WHERE Id = @Room)

			DECLARE @BedsCount INT  = (SELECT Beds FROM Rooms WHERE Id = @Room)

			DECLARE  @HotelBaseRate DECIMAL(18,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
  
			DECLARE @TotalPrice DECIMAL(18, 2) =  (@HotelBaseRate + @RoomPrice) * @People

			RETURN CONCAT('Room ',@Room,': ', @RoomType,' (',@BedsCount,' beds',') - $',@TotalPrice)
END

GO

--------------------------------------------

GO

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TargetRoomHotelId INT = (SELECT HotelID FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @TripHotelId INT = (SELECT r.HotelId
								FROM Trips AS t
								JOIN Rooms AS r ON t.RoomId = r.Id
								WHERE t.id = @TripId)

	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms 
									WHERE Id = @TargetRoomId)
	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips 
								WHERE TripId = @TripId)


	IF(@TargetRoomHotelId <> @TripHotelId)
		THROW 51000, 'Target room is in another hotel!', 1;
	ELSE IF(@TargetRoomBeds < @TripAccounts)
		THROW 51000, 'Not enough beds in target room!', 1;
	ELSE UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
		RETURN @TargetRoomId

GO


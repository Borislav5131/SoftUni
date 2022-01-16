CREATE DATABASE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,	
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL,
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL CHECK(LEN(IssueStatus) = 6),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id) NOT NULL
)

------------------------------------

INSERT INTO Files(Name,Size,ParentId,CommitId) VALUES
('Trade.idk',	2598.0	,1,	1),
('menu.net'	,9238.31,	2,	2),
('dministrate.soshy',	1246.93,	3,	3),
('Controller.php'	,7353.15	,4	,4),
('Find.java',	9957.86,	5,	5),
('Controller.json'	,14034.87,	3,	6),
('Operate.xix',	7662.92	,7	,7)

INSERT INTO Issues (Title,IssueStatus,RepositoryId,AssigneeId) VALUES
('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html',	'open',4 ,3),
('Implement documentation for UsersService.cs',	'closed',	8	,2),
('Unreachable code in Index.cs'	,'open',	9	,8)

--------------------------------------

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

----------------------------------

DELETE FROM Repositories
WHERE Name = 'Softuni-Teamwork'

DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

--------------------------------

SELECT Id
	  ,Message
	  ,RepositoryId
	  ,ContributorId
FROM Commits
ORDER BY Id,Message,RepositoryId,ContributorId

--------------------------------

SELECT Id
	  ,Name
	  ,Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC,Id,Name

-----------------------------

SELECT i.Id
	  ,CONCAT(u.Username,' : ',i.Title)
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id 
ORDER BY i.Id DESC,i.AssigneeId

----------------------------

SELECT Id
	  ,Name
	  ,CONCAT(Size,'KB') AS Size
FROM Files
WHERE Id NOT IN (SELECT ParentId FROM Files WHERE ParentId IS NOT NULL)
ORDER BY Id,Name,Size DESC

-----------------------------

SELECT TOP(5) r.Id	
	  ,r.Name
	  ,COUNT(c.Id) AS Commits
FROM Repositories AS r
RIGHT JOIN Commits AS c ON r.Id = c.RepositoryId
GROUP BY r.Id,r.Name
ORDER BY Commits DESC,r.Id,r.Name

---------------------------------

SELECT Username
	  ,AVG(f.Size)
FROM Commits AS c
JOIN Users AS u ON c.ContributorId = u.Id
LEFT JOIN Files AS f ON c.Id = f.CommitId
ORDER BY Username,f.Name

--------------------------------

GO

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	RETURN( SELECT COUNT(c.Id)
	FROM Users AS u
	LEFT JOIN Commits AS c ON c.ContributorId = u.Id
	WHERE u.Username = @username)
END

GO

-----------------------------

GO

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR)
AS
	SELECT Id
		  ,Name
		  ,CONCAT(Size,'KB')
	FROM Files
	WHERE Name LIKE CONCAT('%',@fileExtension)
	ORDER BY Id,Name,Size DESC
GO

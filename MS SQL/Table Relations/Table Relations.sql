CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber NVARCHAR(30)
)

CREATE TABLE Persons
(
	PersondID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50),
	Salary DECIMAL,
	PassportID INT,
	FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
)

INSERT INTO Passports (PassportID,PassportNumber) VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

INSERT INTO Persons (FirstName,Salary,PassportID) VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101)

------------------------------------------------

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL,
	EstablishedOn DATETIME2
)

INSERT INTO Manufacturers ([Name],EstablishedOn) VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

CREATE TABLE Models
(	
	ModelID INT PRIMARY KEY,
	[Name] VARCHAR(10) NOT NULL,
	ManufacturerID INT,
	FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models (ModelID,[Name],ManufacturerID) VALUES
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

------------------------------------------

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

INSERT INTO Students ([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams
(	
	ExamID INT PRIMARY KEY,
	[Name] VARCHAR(10) NOT NULL
)

INSERT INTO Exams (ExamID,[Name]) VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT,
	PRIMARY KEY (StudentID,ExamID),
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO StudentsExams(StudentID,ExamID) VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

---------------------------------------------------

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

---------------------------------------------------

CREATE DATABASE Store

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(	
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL,
	PRIMARY KEY (OrderID,ItemID)
)



------------------------------------------

SELECT m.MountainRange,p.PeakName,p.Elevation 
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE MountainRange = 'Rila'
ORDER BY p.Elevation DESC


----------------------------------------------

CREATE DATABASE University

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	StudentNumber INT,
	StudentName VARCHAR(50),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY (StudentID,SubjectID)
)

CREATE TABLE Payments
(	
	PaymentID INT PRIMARY KEY,
	PaymentDate DATETIME2,
	PaymentAmount DECIMAL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)
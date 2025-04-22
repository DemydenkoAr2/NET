CREATE TABLE StudentsMarks (
	id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	MidleName NVARCHAR(20),
	Country NVARCHAR(20),
	City NVARCHAR(20),
	BirthDate DATE,
	Email NVARCHAR(50)
	    CONSTRAINT CK_StudentMark_Email_Format 
        CHECK (Email LIKE '%_@__%.__%' AND Email NOT LIKE '% %') UNIQUE,
	PhoneNumber VARCHAR(20) 
		CONSTRAINT CK_StudentMark_PhoneNumber_DigitsOnly 
		CHECK (PhoneNumber NOT LIKE '%[^0-9]%') UNIQUE,
	GroupName NVARCHAR(10),
	AverageGrade DECIMAL(5,2)
		CONSTRAINT CK_StudentMark_AverageGrade_Range 
        CHECK (AverageGrade BETWEEN 0 AND 100),
	SubjectLowestGrade NVARCHAR(20),
	SubjectHighestGrade NVARCHAR(20) 
); 

INSERT INTO StudentsMarks(FirstName, LastName, MidleName, Country, City, BirthDate, Email, PhoneNumber, GroupName, AverageGrade, SubjectLowestGrade, SubjectHighestGrade)
VALUES ('Artem', 'Demydenko', 'Bogdanovich', 'Ukraine', 'Odessa', '1998-11-23', 'Email@Gmail.com', '9253231466', '1-A', 56, 'Math', 'Engl');

INSERT INTO StudentsMarks(FirstName, LastName, MidleName, Country, City, BirthDate, Email, PhoneNumber, GroupName, AverageGrade, SubjectLowestGrade, SubjectHighestGrade)
VALUES 
	('Sam', 'Armstrong', NULL, 'Canada', 'Torront', '2000-12-10', 'Samarm@gmail.com', '9251111414', '4-A', 69, 'Lab', 'PT'),
	('Angela', 'Rodriges', 'Maria', 'Mexico', 'Mexico', '2002-05-15', 'AngelaRod@gmail.com', '452343525', '3-F', 70, 'Biology', 'Cience'),
	('Max', 'Vinogradov', 'Bogdanovich', 'Poland', 'Katowice', '2000-11-22', 'MaxVinog@gmail.com', '423234255', '2-F', 81, 'Tech', 'Biology'),
	('????????', '?????????', '?????????',' Ukraine', 'Odessa', '2002-11-22', 'anat@gmail.com', '88005553535', '1-A', 70, 'Math', 'PT'),
	('Alex', 'Sigmondson', NULL, 'Canada', 'Torronto', '2000-12-10', 'AlexSigmondson@gmail.com', '9251111224', '4-A', 45, 'Tech', 'PT'),
	('Daniel', 'Sadny', NULL, 'Poland', 'Katowice', '2000-11-22', 'Daniel@gmail.com', '411234255', '2-F', 81, 'Tech', 'Biology'),
	('?????', '?????', '??????????',' Ukraine', 'Odessa', '1997-09-03', 'genov@gmail.com', '88115553535', '1-A', 80, 'Math', 'PT'),
	('Tom', 'Sigmondson', NULL, 'Canada', 'Torronto', '2000-12-10', 'Sigmondson@gmail.com', '9253341414', '4-A', 78, 'Tech', 'PT')

--------------------
SELECT * FROM StudentsMarks;

SELECT FirstName, LastName, MidleName FROM StudentsMarks;

SELECT LastName, AverageGrade FROM StudentsMarks

SELECT LastName, FirstName, MidleName, AverageGrade FROM StudentsMarks
WHERE AverageGrade > 60;

SELECT LastName, FirstName, MidleName, AverageGrade FROM StudentsMarks
WHERE AverageGrade < 60;

SELECT DISTINCT Country FROM StudentsMarks;

SELECT DISTINCT City FROM StudentsMarks;

SELECT DISTINCT GroupName From StudentsMarks;

SELECT SubjectLowestGrade AS Subject
FROM StudentsMarks
WHERE SubjectLowestGrade IS NOT NULL

UNION

SELECT SubjectHighestGrade AS Subject
FROM StudentsMarks
WHERE SubjectHighestGrade IS NOT NULL

ORDER BY Subject;
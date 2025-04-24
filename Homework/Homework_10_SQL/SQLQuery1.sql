CREATE TABLE Departments (
    DepartmentId INT NOT NULL IDENTITY(1,1),
    Building INT NOT NULL,
    Financing MONEY NOT NULL DEFAULT 0,
    DepartmentName NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Departments_Id PRIMARY KEY (DepartmentId),
    CONSTRAINT CK_Building_Range CHECK (Building BETWEEN 1 AND 5),
    CONSTRAINT CK_Financing_NotNegative CHECK (Financing >= 0),
    CONSTRAINT CK_Department_Name_NotEmpty CHECK (DepartmentName <> ''),
    CONSTRAINT UQ_Department_Name UNIQUE (DepartmentName)
);

CREATE TABLE Diseases (
    DiseaseId INT NOT NULL IDENTITY(1, 1),
    DiseaseName NVARCHAR(100) NOT NULL,
    Severity INT NOT NULL DEFAULT 1,

    CONSTRAINT PK_Diseases_Id PRIMARY KEY (DiseaseId),
    CONSTRAINT UQ_Disease_Name UNIQUE (DiseaseName),
    CONSTRAINT CK_Disease_Name_NotEmpty CHECK (DiseaseName <> ''),
    CONSTRAINT CK_Severity_NotNegative CHECK (Severity >= 1)
);

CREATE TABLE Doctors(
    DoctorId INT NOT NULL IDENTITY(1, 1),
    FirstName NVARCHAR(MAX) NOT NULL,
    LastName NVARCHAR(MAX) NOT NULL,
    Phone CHAR(10) NULL,
    Salary MONEY NOT NULL,

    CONSTRAINT PK_Doctor_Id PRIMARY KEY (DoctorId),
    CONSTRAINT CK_FirstName_NotEmpty CHECK (FirstName <> ''),
    CONSTRAINT CK_LastName_NotEmpty CHECK (LastName <> ''),
    CONSTRAINT CK_Salary_NotNegative CHECK (Salary >= 0)
);

CREATE TABLE Examinations(
    ExaminationId INT NOT NULL IDENTITY(1, 1),
    ExaminationName NVARCHAR(100) NOT NULL,
    DayOfWeek INT NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,

    CONSTRAINT PK_Examination_Id PRIMARY KEY (ExaminationId),
    CONSTRAINT CK_DayOfWeek_Range CHECK (DayOfWeek BETWEEN 1 AND 7),
    CONSTRAINT CK_StartTime_Range CHECK (StartTime BETWEEN '08:00:00' AND '18:00:00'),
    CONSTRAINT CK_EndTime CHECK (EndTime > StartTime),
    CONSTRAINT UQ_Examination_Name UNIQUE (ExaminationName),
    CONSTRAINT CK_Examination_Name_NotEmpty CHECK (ExaminationName <> '')
);

CREATE TABLE Wards(
    WardId INT NOT NULL IDENTITY(1, 1),
    Building INT NOT NULL,
    Floor INT NOT NULL,
    WardName NVARCHAR(20) NOT NULL,

    CONSTRAINT PK_Wards_Id PRIMARY KEY (WardId),
    CONSTRAINT CK_BuildingWard_Range CHECK (Building BETWEEN 1 AND 5),
    CONSTRAINT CK_Floor_Range CHECK (Floor BETWEEN 1 AND 10),
    CONSTRAINT CK_Ward_Name_NotEmpty CHECK (WardName <> ''),
    CONSTRAINT UQ_Ward_Name UNIQUE (WardName)
);

------------------------

INSERT INTO Departments (Building, Financing, DepartmentName)
VALUES
(1, 50000, 'Cardiology'),
(2, 75000, 'Neurology'),
(3, 60000, 'Oncology'),
(4, 45000, 'Pediatrics'),
(5, 80000, 'Surgery'),
(1, 30000, 'Radiology'),
(2, 55000, 'Dermatology'),
(3, 47000, 'Urology'),
(4, 51000, 'Endocrinology'),
(5, 62000, 'Gastroenterology');

INSERT INTO Diseases (DiseaseName, Severity)
VALUES
('Flu', 2),
('COVID-19', 5),
('Diabetes', 3),
('Hypertension', 2),
('Asthma', 3),
('Cancer', 5),
('Tuberculosis', 4),
('Allergy', 1),
('Migraine', 2),
('Arthritis', 3);

INSERT INTO Doctors (FirstName, LastName, Phone, Salary)
VALUES
('John', 'Smith', '1234567890', 5000),
('Emily', 'Clark', '2345678901', 6000),
('Michael', 'Brown', '3456789012', 7000),
('Sarah', 'Davis', '4567890123', 5200),
('Navid', 'Wilson', '5678901234', 5800),
('Anna', 'Johnson', '6789012345', 6200),
('James', 'Taylor', '7890123456', 6400),
('Laura', 'Anderson', '8901234567', 5600),
('Peter', 'Thomas', '9012345678', 6000),
('Julia', 'Martin', '0123456789', 6800);

INSERT INTO Examinations (ExaminationName, DayOfWeek, StartTime, EndTime)
VALUES
('Blood Test', 1, '08:30:00', '09:00:00'),
('X-Ray', 2, '09:00:00', '09:30:00'),
('MRI', 3, '10:00:00', '11:00:00'),
('Ultrasound', 4, '11:00:00', '11:30:00'),
('ECG', 5, '12:00:00', '12:20:00'),
('CT Scan', 6, '13:00:00', '14:00:00'),
('Endoscopy', 7, '14:30:00', '15:30:00'),
('Biopsy', 1, '15:00:00', '16:00:00'),
('Vision Test', 2, '08:15:00', '08:45:00'),
('Hearing Test', 3, '09:30:00', '10:00:00');

INSERT INTO Wards (Building, Floor, WardName)
VALUES
(1, 1, 'A1'),
(1, 2, 'A2'),
(2, 1, 'B1'),
(2, 2, 'B2'),
(3, 1, 'C1'),
(3, 2, 'C2'),
(4, 1, 'D1'),
(4, 2, 'D2'),
(5, 1, 'E1'),
(5, 2, 'E2');

-----
-- 1. Вивести вміст таблиці палат.
SELECT * FROM Wards;

-- 2. Вивести прізвища та телефони усіх лікарів.
SELECT FirstName, LastName, Phone FROM Doctors;

--3. Вивести усі поверхи без повторень, де розміщуються палати.
SELECT DISTINCT Floor FROM Wards; 

--4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
SELECT 
	DiseaseName AS [Name of Disease],
	Severity AS [Severity of Disease]
FROM Diseases;

--5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.
SELECT D.FirstName, D.LastName, D.Salary
FROM Doctors AS D;

SELECT DZ.DiseaseName, DZ.Severity
FROM Diseases AS DZ;

SELECT DP.DepartmentName, DP.Financing
FROM Departments AS DP;

--6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000.
SELECT DepartmentName
FROM Departments
WHERE Building = 5 AND Financing > 30000;

--7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000.
SELECT DepartmentName 
FROM Departments
WHERE Building = 3 AND (Financing BETWEEN 40000 AND 50000);

--8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
SELECT WardName 
FROM Wards
WHERE (Building = 4 OR Building = 5) AND Floor = 1;

--9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 6 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
SELECT DepartmentName, Financing
FROM Departments
WHERE (Building = 3 OR Building = 6) AND (Financing < 11000 OR Financing > 25000);

--10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
SELECT LastName, Salary
FROM Doctors
WHERE Salary > 6000;

--11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку. ???

--12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
SELECT DISTINCT ExaminationName
From Examinations
WHERE DayOfWeek BETWEEN 1 AND 3 
	AND StartTime >= '10:00:00'
	AND EndTime <= '15:00:00';

--13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
SELECT DepartmentName, Building
FROM Departments
WHERE Building IN (1, 4, 5);

--14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
SELECT DiseaseName
FROM Diseases
WHERE Severity NOT IN (1, 2);

--15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
SELECT DepartmentName
FROM Departments
WHERE Building NOT IN (1, 3);

--16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
SELECT DepartmentName
FROM Departments
WHERE Building IN (1, 3);

--17. Вивести прізвища лікарів, що починаються з літери «N».
SELECT LastName, FirstName
FROM Doctors
WHERE FirstName LIKE 'N%';
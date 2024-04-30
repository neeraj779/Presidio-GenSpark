-- Create the database
CREATE DATABASE dbEmployeeTracker;

-- Select the created database for queries
USE dbEmployeeTracker;

-- Delete the database (if necessary)
USE master;
GO
DROP DATABASE dbEmployeeTracker;

-- Create the 'Areas' Table
CREATE TABLE Areas (
    Area VARCHAR(20),
    Zipcode CHAR(5)
);

-- Set the 'Area' column as primary key
ALTER TABLE Areas
ALTER COLUMN Area VARCHAR(20) NOT NULL;

ALTER TABLE Areas
ADD CONSTRAINT pk_Area PRIMARY KEY(Area);

-- Alternatively, drop and recreate the 'Areas' Table with primary key
DROP TABLE Areas;

CREATE TABLE Areas (
    Area VARCHAR(20) CONSTRAINT pk_Area PRIMARY KEY,
    Zipcode CHAR(5)
);

-- Add a new column 'AreaDescription' to the 'Areas' Table
ALTER TABLE Areas
ADD AreaDescription VARCHAR(200);

-- Drop the 'AreaDescription' column
ALTER TABLE Areas
DROP COLUMN AreaDescription;

-- Create the 'Skills' Table
CREATE TABLE Skills (
    skillId INT IDENTITY (1,1) CONSTRAINT pk_skill PRIMARY KEY,
    Skill VARCHAR(10),
    SkillDescription VARCHAR(30)
);

-- Create the 'Employees' Table
CREATE TABLE Employees (
    id INT IDENTITY(100, 1) CONSTRAINT pk_EmployeeId PRIMARY KEY,
    name VARCHAR(100),
    DateOfBirth DATETIME CONSTRAINT chk_dob CHECK(DateOfBirth<GETDate()),
    EmployeeArea VARCHAR(20) CONSTRAINT fk_Area FOREIGN KEY REFERENCES Areas(Area),
    phone VARCHAR(13),
    email VARCHAR(100) NOT NULL
);

-- Create the 'EmployeeSkill' Table
CREATE TABLE EmployeeSkill (
    Employee_id INT CONSTRAINT fk_skill_eid FOREIGN KEY REFERENCES Employees(id),
    Skill INT CONSTRAINT fk_Skill_EmplSkill FOREIGN KEY REFERENCES Skills(skillId),
    skillLevel FLOAT CONSTRAINT chk_skilllevel CHECK(skillLevel>=0),
    CONSTRAINT pk_employee_skill PRIMARY KEY(Employee_id, Skill)
);

-- Display information about the 'Areas' Table
EXEC sp_help Areas;

-- Data Manipulation Language (DML) Operations

-- Insert data into the 'Areas' Table
INSERT INTO Areas(Area, Zipcode) VALUES('DDDD', '1234');
INSERT INTO Areas(Zipcode, Area) VALUES('124', 'FFFF');
INSERT INTO Areas VALUES('ABCD', '255');

-- Insertion Failures
INSERT INTO Areas(Area,Zipcode) VALUES('DDDD','12345'); -- Primary key duplication
INSERT INTO Areas(Area,Zipcode) VALUES('OOOO','12345334'); -- Size violation
INSERT INTO Areas(Zipcode) VALUES('12345'); -- Primary key null

-- Display data from the 'Areas' Table
SELECT * FROM Areas;

-- Insert data into the 'Skills' Table
INSERT INTO skills(Skill,SkillDescription) VALUES('C','PLT');
INSERT INTO skills(Skill,SkillDescription) VALUES('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS');

-- Display data from the 'Skills' Table
SELECT * FROM skills;

-- Foreign Key Insertion into the 'Employees' Table
INSERT INTO Employees (name, DateOfBirth, EmployeeArea, phone, email)
VALUES('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com');
INSERT INTO Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
VALUES('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com');

-- Display data from the 'Employees' Table
SELECT * FROM Employees;

-- Insert data into the 'EmployeeSkill' Table (using composite key)
INSERT INTO EmployeeSkill VALUES(101,3,8);

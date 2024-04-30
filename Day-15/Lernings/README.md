## EF Codd's Relational Model

## Entity/Relation
- **Strong**: Has a Primary Key (PK)
- **Weak**: Lacks a Primary Key
- **Derived**: Based on other attributes

## Attribute
- **Simple**: Single unit of data
- **Multi-Valued**: Contains more than one unit of data, cannot be split
- **Complex**: Contains more than one unit of data, can be split into multiple attributes
- **Derived**: Value derived from another attribute

## Tuple

## Key Definitions
- **Primary Key (PK)**: Must be unique and not null
- **Foreign Key (FK)**: Refers to the primary key of another entity in the current entity
- **Composite Key**: Combination of multiple attributes forming the primary key

# Normalization

## First Normal Form (1NF)
- No multi-valued attributes
- Primary key is mandatory
- Data in each attribute should be of similar datatype

## Second Normal Form (2NF)
- Entity must be in 1NF
- No partial dependency

## Third Normal Form (3NF)
- Entity must be in 2NF
- No transitive dependency

# SQL
- **DDL**: Data Definition Language
- **DML**: Data Manipulation Language
- **DQL**: Data Query Language


# Database Operations

## Create Database

```sql
CREATE DATABASE `dbEmployeeTracker`;
```

## Select Database

```sql
USE dbEmployeeTracker;
```

## Delete Database

```sql
USE master;
GO
DROP DATABASE dbEmployeeTracker;
```

# Table Operations

## Create Table: Areas

```sql
CREATE TABLE Areas (
    Area VARCHAR(20),
    Zipcode CHAR(5)
);
```

## Set Primary Key for Areas Table

```sql
-- Option 1: Edit the 'Area' column to be primary key
ALTER TABLE `Areas`
ALTER COLUMN Area VARCHAR(20) NOT NULL;

ALTER TABLE Areas
ADD CONSTRAINT pk_Area PRIMARY KEY(Area);

-- Option 2: Drop and recreate the table
DROP TABLE Areas;

CREATE TABLE Areas (
    Area VARCHAR(20) CONSTRAINT pk_Area PRIMARY KEY,
    Zipcode CHAR(5)
);
```

## Add Column to Areas Table

```sql
ALTER TABLE Areas
ADD AreaDescription VARCHAR(200);
```

## Drop Column from Areas Table

```sql
ALTER TABLE Areas
DROP COLUMN AreaDescription;
```

## Create Table: Skills

```sql
CREATE TABLE Skills (
    skillId INT IDENTITY (1,1) CONSTRAINT pk_skill PRIMARY KEY,
    Skill VARCHAR(10),
    SkillDescription VARCHAR(30)
);
```

## Create Table: Employees

```sql
CREATE TABLE Employees (
    id INT IDENTITY(100, 1) CONSTRAINT pk_EmployeeId PRIMARY KEY,
    name VARCHAR(100),
    DateOfBirth DATETIME CONSTRAINT chk_dob CHECK(DateOfBirth<GETDATE()),
    EmployeeArea VARCHAR(20) CONSTRAINT fk_Area FOREIGN KEY REFERENCES Areas(Area),
    phone VARCHAR(13),
    email VARCHAR(100) NOT NULL
);
```

## Create Table: EmployeeSkill

```sql
CREATE TABLE EmployeeSkill (
    Employee_id INT CONSTRAINT fk_skill_eid FOREIGN KEY REFERENCES Employees(id),
    Skill INT CONSTRAINT fk_Skill_EmplSkill FOREIGN KEY REFERENCES Skills(skillId),
    skillLevel FLOAT CONSTRAINT chk_skilllevel CHECK(skillLevel>=0),
    CONSTRAINT pk_employee_skill PRIMARY KEY(Employee_id, Skill)
);
```

## Display Table Information for Areas Table

```sql
EXEC sp_help Areas;
```

# Data Manipulation Language (DML) Operations

## Insert Data into Areas Table

```sql
INSERT INTO Areas(Area, Zipcode) VALUES('DDDD', '1234');
INSERT INTO Areas(Zipcode, Area) VALUES('124', 'FFFF');
INSERT INTO Areas VALUES('ABCD', '255');
```

## Insertion Failures for Areas Table

```sql
-- Primary key duplication
INSERT INTO Areas(Area,Zipcode) VALUES('DDDD','12345');

-- Size violation
INSERT INTO Areas(Area,Zipcode) VALUES('OOOO','12345334');

-- Primary key null
INSERT INTO Areas(Zipcode) VALUES('12345');
```

## Display Data from Areas Table

```sql
SELECT * FROM Areas;
```

## Insert Data into Skills Table

```sql
INSERT INTO skills(Skill,SkillDescription) VALUES('C','PLT');
INSERT INTO skills(Skill,SkillDescription) VALUES('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS');
```

## Display Data from Skills Table

```sql
SELECT * FROM skills;
```

## Foreign Key Insertion into Employees Table

```sql
INSERT INTO Employees (name, DateOfBirth, EmployeeArea, phone, email)
VALUES('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com');

INSERT INTO Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
VALUES('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com');
```

## Display Data from Employees Table

```sql
SELECT * FROM Employees;
```

## Insert Data into EmployeeSkill Table (using composite key)

```sql
INSERT INTO EmployeeSkill VALUES(101,3,8);
```

Create Database EmployeesDB;

use EmployeesDB;

CREATE TABLE Employees (
	ID int NOT NULL,
    Name varchar(30) NOT NULL,
    Surname varchar(30) NOT NULL,
	Description text NULL,
    PRIMARY KEY (ID)
);

Create Table Skills(
	ID int NOT NULL,
    Name varchar(30) NOT NULL,
	Description text NULL,
    PRIMARY KEY (ID)
);

Create Table EmplSkills(
RelationID int NOT NUll,
EmplID int NOT NULL,
SkillID int NOT NULL,
PRIMARY KEY(SkillID),
FOREIGN KEY (EmplID) REFERENCES Employees(ID) ON Update cascade ON delete cascade,
FOREIGN KEY (SkillID) REFERENCES Skills(ID) ON Update cascade ON delete cascade,
);

CREATE INDEX SkillRelations
ON EmplSkills (RelationID,EmplID);



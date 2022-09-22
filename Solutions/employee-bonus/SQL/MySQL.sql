-- Create Items
CREATE TABLE IF NOT EXISTS Employee
(
    empId      int,
    name       varchar(255),
    supervisor int,
    salary     int
);
CREATE TABLE IF NOT EXISTS Bonus
(
    empId int,
    bonus int
);
TRUNCATE TABLE Employee;
INSERT INTO Employee
VALUES (1, 'John', 3, 1000),
       (2, 'Dan', 3, 2000),
       (3, 'Brad', NULL, 4000),
       (4, 'Thomas', 3, 4000);
TRUNCATE TABLE Bonus;
INSERT INTO Bonus
VALUES (2, 500),
       (4, 2000);

-- Write your Postgres query statement below
SELECT Employee.name, B.bonus
FROM Employee
         LEFT JOIN Bonus B on Employee.empId = B.empId
WHERE B.bonus < 1000
   or B.bonus IS NULL;

-- Remove Data
DROP TABLE Employee, Bonus;
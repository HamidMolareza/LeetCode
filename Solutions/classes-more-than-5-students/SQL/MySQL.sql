-- Create Items
Create table If Not Exists Courses (student varchar(255), class varchar(255));
Truncate table Courses;
insert into Courses (student, class) values 
    ('A', 'Math'),
    ('B', 'English'),
    ('C', 'Math'),
    ('D', 'Biology'),
    ('E', 'Math'),
    ('F', 'Computer'),
    ('G', 'Math'),
    ('H', 'Math'),
    ('I', 'Math');

-- Write your MySQL query statement below
SELECT class
FROM Courses
GROUP BY class
HAVING COUNT(*) >= 5

-- Remove Data
DROP TABLE Courses;
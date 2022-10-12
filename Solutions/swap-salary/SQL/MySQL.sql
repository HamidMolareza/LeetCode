-- Create Items
Create table If Not Exists Salary (id int, name varchar(100), sex char(1), salary int);
Truncate table Salary;
insert into Salary (id, name, sex, salary)
values ('1', 'A', 'm', '2500'),
       ('2', 'B', 'f', '1500'),
       ('3', 'C', 'm', '5500'),
       ('4', 'D', 'f', '500');

-- Write your MySQL query statement below
update Salary
set sex=if(sex='m', 'f', 'm')

-- Remove Data
DROP TABLE Salary;
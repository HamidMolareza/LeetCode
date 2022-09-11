-- Create Items
Create table If Not Exists Employee
(
    id        int,
    name      varchar(255),
    salary    int,
    managerId int
);
Truncate table Employee;
insert into Employee (id, name, salary, managerId)
values ('1', 'Joe', '70000', '3')
     , ('2', 'Henry', '80000', '4')
     , ('3', 'Sam', '60000', NULL)
     , ('4', 'Max', '90000', NULL);

-- Write your MySQL query statement below
SELECT employee.name AS Employee
FROM Employee employee, Employee manager
WHERE employee.managerId=manager.id
  AND employee.salary > manager.salary;

-- Remove Data
DROP TABLE Employee;

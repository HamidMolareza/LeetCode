-- use master database to avoid error during database drop
use master;
go

-- drop database if exists
if db_id('LeetCode') is not null
    begin
        alter database LeetCode set single_user with rollback immediate;
        drop database LeetCode;
    end
go

-- create new database
create database LeetCode;
go
use LeetCode;
go

-- create tables
create table Employee (
    empId int primary key,
    name nvarchar(50),
    salary int,
    managerId int
);

-- insert sample data
insert into Employee (empId, name, salary, managerId) values 
(1, 'Joe', 70000, 3),
(2, 'Henry', 80000, 4),
(3, 'Sam', 60000, null),
(4, 'Max', 90000, null);

-- Solution
select e1.name as Employee
from Employee e1
join Employee e2 on e1.managerId = e2.empId
where e1.salary > e2.salary;


-- switch to master before drop
use master;
go

-- drop database after use
if db_id('LeetCode') is not null
    begin
        alter database LeetCode set single_user with rollback immediate;
        drop database LeetCode;
    end
go

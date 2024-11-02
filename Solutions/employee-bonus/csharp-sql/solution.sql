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
    name varchar(50),
    salary int
);

create table Bonus (
    empId int,
    bonus int,
    foreign key (empId) references Employee(empId)
);

-- insert sample data
insert into Employee (empId, name, salary) values
(1, 'John', 1000),
(2, 'Doe', 2000),
(3, 'Jane', 3000),
(4, 'Smith', 4000);

insert into Bonus (empId, bonus) values
(2, 500),
(3, 1000);


-- Solution
select e.name, b.bonus
from Employee e
left join Bonus b
on e.empId = b.empId;


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

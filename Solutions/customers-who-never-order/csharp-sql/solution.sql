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
create table Customers
(
    id int primary key,
    name nvarchar(50)
);

create table Orders
(
    id int primary key,
    customerId int
);

-- insert sample data
insert into Customers
    (id, name)
values
    (1, 'Joe'),
    (2, 'Henry'),
    (3, 'Sam'),
    (4, 'Max');

insert into Orders
    (id, customerId)
values
    (1, 3),
    (2, 1);


-- Solution 1
select name as Customers
from Customers
where id not in (select customerId
from Orders);

-- Solution 2
select name as Customers
from Customers c
    left join Orders o
    on c.id = o.customerId
where o.id is null;

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

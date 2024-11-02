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
create table Person (
    id int primary key,
    email nvarchar(100)
);

-- insert sample data
insert into Person (id, email) values 
(1, 'a@example.com'),
(2, 'b@example.com'),
(3, 'a@example.com');


-- Solution
delete p1
from Person p1
join Person p2 on p1.email = p2.email and p1.id > p2.id;

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

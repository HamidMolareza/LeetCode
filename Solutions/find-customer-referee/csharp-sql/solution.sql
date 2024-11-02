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
create table Customer (
    id int primary key,
    name varchar(50),
    referee_id int
);

-- insert sample data
insert into Customer (id, name, referee_id) values
(1, 'Will', null),
(2, 'Jane', null),
(3, 'Alex', 2),
(4, 'Bill', null),
(5, 'Zoe', 1),
(6, 'Chris', 2);

-- Solution
select name
from Customer
where referee_id is null or referee_id != 2;


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

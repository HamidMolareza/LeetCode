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
create table Weather (
    id int primary key,
    recordDate date,
    temperature int
);

-- insert sample data
insert into Weather (id, recordDate, temperature) values
(1, '2023-07-01', 30),
(2, '2023-07-02', 35),
(3, '2023-07-03', 40),
(4, '2023-07-04', 38),
(5, '2023-07-05', 42),
(6, '2023-07-06', 36);


-- Solution
select w1.id, w1.recordDate
from Weather w1
join Weather w2
on w1.recordDate = dateadd(day, 1, w2.recordDate)
where w1.temperature > w2.temperature;


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

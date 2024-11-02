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


-- insert sample data


-- Solution


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

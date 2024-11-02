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
create table Person
(
    personId  int primary key,
    lastName  varchar(255),
    firstName varchar(255)
);

create table Address
(
    addressId int primary key,
    personId  int,
    city      varchar(255),
    state     varchar(255),
    foreign key (personId) references Person (personId)
);

-- insert sample data
insert into Person (personId, lastName, firstName)
values (1, 'Smith', 'John'),
       (2, 'Johnson', 'Jane'),
       (3, 'Williams', 'Chris');

insert into Address (addressId, personId, city, state)
values (1, 1, 'New York', 'NY'),
       (2, 2, 'Los Angeles', 'CA');


-- Solution
select p.firstName, p.lastName, a.city, a.state
from Person p
         left join Address a on p.personId = a.personId;


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

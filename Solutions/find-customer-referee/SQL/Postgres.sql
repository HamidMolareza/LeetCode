-- Create Items
Create table If Not Exists Customer
(
    id         int,
    name       varchar(25),
    referee_id int
);
Truncate table Customer;
insert into Customer (id, name, referee_id)
values ('1', 'Will', null)
     , ('2', 'Jane', null)
     , ('3', 'Alex', '2')
     , ('4', 'Bill', null)
     , ('5', 'Zack', '1')
     , ('6', 'Mark', '2');

-- Write your Postgres query statement below
SELECT name
FROM Customer
WHERE referee_id IS NULL
   OR referee_id <> 2;

-- Remove Data
DROP TABLE Customer;
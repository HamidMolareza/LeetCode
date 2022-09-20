-- Create Items
Create table If Not Exists Customer
(
    id         int,
    name       varchar(25),
    referee_id int
    );
Truncate table Customer;
insert into Customer (id, name, referee_id)
values ('1', 'Will', 'None')
     , ('2', 'Jane', 'None')
     , ('3', 'Alex', '2')
     , ('4', 'Bill', 'None')
     , ('5', 'Zack', '1')
     , ('6', 'Mark', '2');

-- Write your MySQL query statement below
SELECT name
FROM Customer
WHERE referee_id IS NULL
   OR referee_id <> 2

-- Remove Data
DROP TABLE Customer;
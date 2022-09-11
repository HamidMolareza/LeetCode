-- Create Items
Create table If Not Exists Person
(
    personId  int,
    firstName varchar(255),
    lastName  varchar(255)
);
Create table If Not Exists Address
(
    addressId int,
    personId  int,
    city      varchar(255),
    state     varchar(255)
);
Truncate table Person;
insert into Person (personId, lastName, firstName)
values ('1', 'Wang', 'Allen'),
       ('2', 'Alice', 'Bob');
Truncate table Address;
insert into Address (addressId, personId, city, state)
values ('1', '2', 'New York City', 'New York'),
       ('2', '3', 'Leetcode', 'California');

-- Write your MySQL query statement below
SELECT Person.firstName, Person.lastName, Address.city, Address.state
FROM Person
         LEFT JOIN Address
                   ON Address.personId = Person.personId;

-- Remove Data
DROP TABLE Person;
DROP TABLE Address;
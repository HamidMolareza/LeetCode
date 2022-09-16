-- Create Items
Create table If Not Exists Person
(
    id    int,
    email varchar(255)
);
Truncate table Person;
insert into Person (id, email)
values ('1', 'a@b.com'),
       ('2', 'c@d.com'),
       ('3', 'a@b.com');


-- Write your MySQL query statement below
SELECT email
FROM Person
GROUP BY email
HAVING COUNT(email) > 1;

-- Remove Data
DROP TABLE Person;
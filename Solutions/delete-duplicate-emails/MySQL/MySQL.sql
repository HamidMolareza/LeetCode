-- Create Items
Create table If Not Exists Person
(
    id    int,
    email varchar(255)
);
Truncate table Person;
insert into Person (id, email)
values ('1', 'john@example.com')
     , ('2', 'bob@example.com')
     , ('3', 'john@example.com');

-- Write your MySQL query statement below
DELETE person1.*
FROM Person person1, Person person2
WHERE person1.email = person2.email
  AND person1.id > person2.id;

SELECT * FROM Person;


-- Remove Data
DROP TABLE Person;
-- Create Items
Create table If Not Exists ActorDirector (actor_id int, director_id int, timestamp int);
Truncate table ActorDirector;
insert into ActorDirector (actor_id, director_id, timestamp)
values ('1', '1', '0'),
       ('1', '1', '1'),
       ('1', '1', '2'),
       ('1', '2', '3'),
       ('1', '2', '4'),
       ('2', '1', '5'),
       ('2', '1', '6');

-- Write your MySQL query statement below
select actor_id, director_id
from ActorDirector
group by actor_id, director_id
having count(*) >= 3

-- Remove Data
DROP TABLE ActorDirector;
-- Create Items
create table if not exists Points(
    Id  serial primary key,
    point   int
);
truncate table Points;
insert into Points(point) values
(-1),(0),(2);

-- Write your Postgres query statement below
select min(abs(p1.point - p2.point)) 
from Points p1, Points p2
where p1.Id < p2.Id;

-- Remove Data
DROP TABLE Points;
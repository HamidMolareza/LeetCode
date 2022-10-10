-- Create Items
create table if not exists Triangle(
    id  serial primary key,
    x   int,
    y   int,
    z   int
);
truncate table Triangle;
insert into Triangle(x,y,z) values
    (13, 15, 30),
    (10, 20, 15);

-- Write your MySQL query statement below
select *,
       if(x+y>z and x+z>y and y+z>x, 'Yes', 'No') as triangle
from triangle

-- Remove Data
DROP TABLE Triangle;
-- Create Items
create table if not exists Numbers(
    Id  serial primary key,
    number  int
);
truncate table Numbers;
insert into Numbers(number) values 
(8),(8),(3),(3),(1),(4),(5),(6);

-- Write your Postgres query statement below
select number
from Numbers
group by number
having count(*) = 1
order by number desc
limit 1; 

-- Remove Data
DROP TABLE Numbers;
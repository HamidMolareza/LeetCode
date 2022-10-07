-- Create Items
create table if not exists Cinema(
    seat_id serial primary key,
    free bool
);
truncate table Cinema;
insert into Cinema(free) values
(true),
(false),
(true),
(true),
(true);
                          

-- Write your Postgres query statement below
select distinct seat1.seat_id
from Cinema seat1, Cinema seat2
where (seat2.seat_id - seat1.seat_id = 1 or seat1.seat_id - seat2.seat_id = 1)
  and (seat1.free and seat2.free);

-- Remove Data
DROP TABLE Cinema;
-- Create Items
Create table If Not Exists Weather
(
    id
    int,
    recordDate
    date,
    temperature
    int
);
Truncate table Weather;
insert into Weather
(id,
 recordDate,
 temperature)
values ('1',
        '2015-01-01',
        '10')
        ,
       ('2',
        '2015-01-02',
        '25')
        ,
       ('3',
        '2015-01-03',
        '20')
        ,
       ('4',
        '2015-01-04',
        '30');

-- Write your MySQL query statement below
SELECT w2.id
FROM Weather w1, Weather w2
WHERE DATEDIFF(w2.recordDate, w1.recordDate) = 1
  AND w2.temperature > w1.temperature;

-- Remove Data
DROP TABLE Weather;
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
SELECT w.id AS 'Id'
FROM Weather
         JOIN Weather w
              ON DATEDIFF(w.recordDate, Weather.recordDate) = 1
                  AND w.Temperature > Weather.Temperature;

-- Remove Data
DROP TABLE Weather;
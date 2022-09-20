-- Create Items
Create table If Not Exists orders
(
    order_number
    int,
    customer_number
    int
);
Truncate table orders;
insert into orders (order_number, customer_number)
values ('1', '1')
     , ('2', '2')
     , ('3', '3')
     , ('4', '3');

-- Write your MySQL query statement below
SELECT customer_number
FROM orders
GROUP BY customer_number
ORDER BY COUNT(*) DESC
    LIMIT 1;

-- Remove Data
DROP TABLE orders;
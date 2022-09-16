-- Create Items
Create table If Not Exists Customers
(
    id
        int,
    name
        varchar(255)
);
Create table If Not Exists Orders
(
    id
        int,
    customerId
        int
);
Truncate table Customers;
insert into Customers (id, name)
values ('1', 'Joe'),
       ('2', 'Henry'),
       ('3', 'Sam'),
       ('4', 'Max');
Truncate table Orders;
insert into Orders (id, customerId)
values ('1', '3'),
       ('2', '1');


-- Write your MySQL query statement below
SELECT name AS Customers
FROM Customers
WHERE id NOT IN (
    SELECT customerId
    from Orders
);


-- Remove Data
DROP TABLE Customers, Orders;
-- Create Items
Create table If Not Exists SalesPerson
(
    sales_id        int,
    name            varchar(255),
    salary          int,
    commission_rate int,
    hire_date       date
);
Create table If Not Exists Company
(
    com_id int,
    name   varchar(255),
    city   varchar(255)
);
Create table If Not Exists Orders
(
    order_id   int,
    order_date date,
    com_id     int,
    sales_id   int,
    amount     int
);
Truncate table SalesPerson;
insert into SalesPerson (sales_id, name, salary, commission_rate, hire_date)
values ('1', 'John', '100000', '6', '4/1/2006')
     , ('2', 'Amy', '12000', '5', '5/1/2010')
     , ('3', 'Mark', '65000', '12', '12/25/2008')
     , ('4', 'Pam', '25000', '25', '1/1/2005')
     , ('5', 'Alex', '5000', '10', '2/3/2007');
Truncate table Company;
insert into Company (com_id, name, city)
values ('1', 'RED', 'Boston')
     , ('2', 'ORANGE', 'New York')
     , ('3', 'YELLOW', 'Boston')
     , ('4', 'GREEN', 'Austin');
Truncate table Orders;
insert into Orders (order_id, order_date, com_id, sales_id, amount)
values ('1', '1/1/2014', '3', '4', '10000')
     , ('2', '2/1/2014', '4', '5', '5000')
     , ('3', '3/1/2014', '1', '1', '50000')
     , ('4', '4/1/2014', '1', '4', '25000');

-- Write your Postgres query statement below
select name
from SalesPerson
where sales_id not in (
    select Orders.sales_id
    from Orders
             join Company C on Orders.com_id = C.com_id
    where C.name = 'RED'
);

-- Remove Data
DROP TABLE SalesPerson, Company, Orders;
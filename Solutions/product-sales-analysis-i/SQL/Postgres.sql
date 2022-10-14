-- Create Items
create table if not exists Sales
(
    sale_id    int,
    product_id int,
    year       int,
    quantity   int,
    price      int,
    primary key (sale_id, year),
    foreign key (product_id) references Product(product_id)
);
truncate table Sales;
insert into Sales
values (1, 100, 2008, 10, 5000),
       (2, 100, 2009, 12, 5000),
       (7, 200, 2011, 15, 9000);

create table if not exists Product
(
    product_id   int primary key,
    product_name varchar
);
truncate table Product;
insert into Product
values (100, 'Nokia'),
       (200, 'Apple'),
       (300, 'Samsung');

-- Write your Postgres query statement below
select p.product_name, Sales.year, Sales.price
from Sales
join Product P on Sales.product_id = P.product_id;

-- Remove Data
DROP TABLE Sales, Product;
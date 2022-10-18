-- Create Items
create table if not exists Project
(
    project_id  int,
    employee_id int,
    primary key (project_id, employee_id)
);
truncate table Project;
insert into Project
values (1, 1),
       (1, 2),
       (1, 3),
       (2, 1),
       (2, 4);

create table if not exists Employee
(
    employee_id      serial primary key,
    name             varchar,
    experience_years int
);
truncate table Employee;
insert into Employee (name, experience_years)
values ('Khaled', 3),
       ('Ali', 2),
       ('John', 1),
       ('Doe', 2);

-- Write your Postgres query statement below
SELECT project_id
FROM Project
GROUP BY project_id
ORDER BY COUNT(employee_id) DESC
LIMIT 1;

-- Remove Data
DROP TABLE Project, Employee;
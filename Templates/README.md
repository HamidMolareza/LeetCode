# About Templates

With the help of these templates, you can start solving the problem faster and easier. For example, if you are going to
solve a database problem, you can use the [MySQL](MySQL) template.

## Getting Started

1. Specify what problem you want to solve. For example, we want to solve
   the [combine-two-tables problem](https://leetcode.com/problems/combine-two-tables).

2. Specify in which language you want to solve the problem. For example, `MySQL`.

3. Choose the closest template. In the previous example, it is the [MySQL](MySQL) template.

4. Consider the problem name (from url). In the previous example, it is the `combine-two-tables`

5. Change your directory to `Templates` directory:

`cd Templates`

6. Run `create-template.sh` shell with this command:

`./create-template.sh 'problem-name' 'template path' 'solutions-directory-path'`

In the previous example:

`./create-template.sh 'combine-two-tables' 'MySQL' '../Solutions'`

> Note: the `'solutions-directory-path'` is optional. The default value is `'solutions-directory-path'`.
>
> So you can use this command:
> `./create-template.sh 'combine-two-tables' 'MySQL'`

7. Go to solution directory:

`../Solutions/problem-name/template-name`

In the previous example, solution directory is: `../Solutions/combine-two-tables/MySQL`

10. Solve the problem

11. Commit

12. (Optional) You can merge this branch into master branch with `merge-into-master-branch.sh` shell.

Run the shell:
`./merge-into-master-branch.sh 'problem-name'`

In the previous example:
`./merge-into-master-branch.sh 'combine-two-tables'`

## Templates

### Template: csharp-sql-database

With the help of this template, you can solve database problems in **C#** language.

Various databases are supported in this template. There are also different docker-compose files for running databases.

You can implement your own solution in the `Solution` method and view the output and execution time on the console
screen with the help of pre-made methods.

#### Getting Started

1. Create Models in `Models` directory

2. Update `ProblemContext.cs`
    - Add `DbSet` properties
    - Update `SeedDataAsync` method

3. Check `AppSettings.json` and ensure everything ok. (if necessary, update `DatabaseType` and `ConnectionString`)

4. If your database is not **memory** type, ensure your database service is run. (run service or run docker-compose
   from `Docker-Compose` directory)

5. Open the `Program.cs` and implement your solution in `Solution` method.

For more information see [template readme file](csharp-sql-database/README.md).

### Template: csharp

With the help of this template, you can solve problems in **C#** language.

There are two projects in this template. 1- The `Solution` project: to implement the solution 2- The `TestSolution`
project: for the tests

### Template: MySQL

With the help of this template, you can solve database problems in **MySQL** language.

For more information see [template readme file](MySQL/README.md).
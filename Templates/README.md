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

`./create-template.sh 'problem-name' 'template path' 'simple-code-editor-name-like-vscode' 'favorite-ide-name-like-webstorm' 'solutions-directory-path'`

In the previous example:

`./create-template.sh 'combine-two-tables' 'MySQL' 'code' 'rider' '../Solutions'`

> Note: the `'solutions-directory-path'` is optional. The default value is `'solutions-directory-path'`.
>
> So you can use this command:
> `./create-template.sh 'combine-two-tables' 'MySQL' 'code' 'rider'`

7. Solve the problem

If it is the first time that this problem is going to be solved, the text editor will open for you to put the text of the problem there.
Then your desired IDE will be opened in the problem directory to solve the problem.

8. Commit Solution

9. Merge to master branch

After you solve the problem, close the IDE.
Then go back to the console.
You will be asked if you want to merge this branch with the master branch. If you want, enter the `y` to merge this branch with the master branch.

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

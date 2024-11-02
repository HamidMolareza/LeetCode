# Intuition

To find each employee and their bonus, we want to include all employees, even if they don’t have a corresponding bonus entry. This way, we can show `null` for those without bonuses.

# Approach

1. Perform a `LEFT JOIN` on the `Employee` and `Bonus` tables.
2. Select the employee name and bonus amount (or `null` if no bonus is recorded).

# Complexity

- Time complexity: `O(n)`, where `n` is the number of employees, since we are primarily scanning the Employee table and optionally joining with the Bonus table.
- Space complexity: `O(1)`, as the query output doesn’t use additional data structures proportional to input size.

# Other Solutions

Another option is to use a subquery to get the bonus for each employee, but a `LEFT JOIN` is generally more efficient and readable for this type of data retrieval.

> This text was written by ChatGPT.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

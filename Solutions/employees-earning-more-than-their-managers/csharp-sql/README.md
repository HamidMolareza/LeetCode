# Intuition

The problem asks us to find employees who earn more than their managers. The solution requires comparing each employee's salary with their manager's salary to filter those who satisfy this condition.

# Approach

To solve this, we need to join the `Employee` table to itself on the condition that the `managerId` of an employee matches the `empId` of their manager. Then, we add a filter to check if the employee's salary is greater than the manager's salary.

# Complexity

- Time complexity: `O(n)`  
  We are performing a join, which takes `O(n)` if indexed properly.
- Space complexity: `O(1)`  
  Constant space is used, as no additional data structures are required.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

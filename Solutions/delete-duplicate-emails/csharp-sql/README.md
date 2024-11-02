# Intuition

The task requires us to remove duplicate emails, retaining only the entry with the smallest `id` for each email. This can be achieved by identifying rows with duplicate emails and deleting those with higher IDs.

# Approach

We can use a self-join to match each email with itself, keeping only the row with the smallest ID. Specifically, we delete rows where a higher `id` matches an existing email with a lower ID.

# Complexity

- Time complexity: `O(n^2)`  
  The join operation pairs each row with potential duplicates, making it quadratic in complexity.

- Space complexity: `O(1)`  
  Constant space is used, as we perform the deletion in place without extra structures.

# Other Solutions

Another solution is to use a common table expression (CTE) with `row_number()` to rank rows by ID within each email group. While this approach is also effective, it’s more complex for simple scenarios and not universally supported.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

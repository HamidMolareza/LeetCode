# Intuition

To find customers whose `referee_id` is neither `null` nor `2`, we can directly filter on the `referee_id` column.

# Approach

1. Filter `Customer` records with a `referee_id` that is not `null` and not equal to `2`.
2. Select only the customer names that meet this criterion.

# Complexity

- Time complexity: `O(n)`, where `n` is the number of customers, as we’re scanning the `Customer` table once.
- Space complexity: `O(1)`, since the query does not need additional space that grows with input size.

> This text was written by ChatGPT.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

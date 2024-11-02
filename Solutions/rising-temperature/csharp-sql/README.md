# Intuition

To identify days with a temperature increase compared to the previous day, we can check for each record whether the temperature was higher than on the day before.

# Approach

1. Use a self-join to pair each date with the previous date.
2. Check that the temperature on the current date is greater than the temperature on the previous date.

# Complexity

- Time complexity: `O(n)`, where `n` is the number of records, because we’re scanning and comparing records linearly.
- Space complexity: `O(1)`, as the query does not use additional data structures that grow with input.

# Other Solutions

An alternative is using a window function like `LEAD()` or `LAG()` to directly compare rows. However, since it may not be available in all database systems, the self-join approach provides broader compatibility.

> This text was written by ChatGPT.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

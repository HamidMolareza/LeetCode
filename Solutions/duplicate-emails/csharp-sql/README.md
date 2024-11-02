# Intuition

The task requires identifying duplicate email addresses in a table. Using the `group by` clause will allow us to count the occurrences of each email and filter for those appearing more than once.

# Approach

We can use SQL’s `group by` with `having count(*) > 1` to identify emails with duplicates. This approach efficiently groups the records and then applies a filter to select only those with a count greater than one.

# Complexity

- Time complexity: `O(n)`  
  We iterate through all emails once to group and count them.

- Space complexity: `O(1)`  
  Constant space is used as no additional data structures are needed.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

# Intuition

To find customers who never placed an order, we need to identify customers whose IDs are absent in the Orders table. This is a classic case of using exclusion.

# Approach

We can use a `not in` subquery to filter customers by excluding those whose `id` appears in the Orders table. This approach effectively identifies customers with no orders in a single query.

# Complexity

- Time complexity: `O(n + m)`  
  Here `n` is the number of customers and `m` is the number of orders. We iterate through both tables once.

- Space complexity: `O(1)`  
  Constant space is used since we don't require any extra data structures.

# Other Solutions

An alternative solution is a left join with `null` filtering, where we join `Customers` to `Orders` and select customers with no matching orders. While effective, `not in` is simpler and performs well in this scenario.

# Codes

- [SQL](solution.sql)
- [C# LINQ](CsharpSql/Program.cs)

# Intuition

The problem involves combining data from two tables, `Person` and `Address`, to display a list of all persons along with
their city and state information if available. This is a classic example of an outer join where we want to ensure all
records from the `Person` table appear in the output, even if there is no corresponding record in the `Address` table.

# Approach

The solution uses a `LEFT JOIN` to combine the `Person` and `Address` tables on the `personId` field. This ensures that
all rows from the `Person` table are included in the result, even if a matching `Address` entry does not exist. If there
is no matching address, `city` and `state` fields will be returned as `NULL`.

# Complexity

- Time complexity: `O(n)`, where `n` is the number of rows in the `Person` table, assuming indexed joins.
- Space complexity: `O(n)`, storing the result in memory.

# Other Solutions

An alternative approach could involve using a `FULL OUTER JOIN`, but this is less optimal here since we only need all
records from `Person`, not both tables. The `LEFT JOIN` approach is more straightforward and efficient for the desired
output.

# Intuition

The problem involves finding the number of distinct ways to climb `n` stairs, where you can take either 1 step or 2 steps at a time. This can be thought of as a combinatorial problem where the total number of ways to reach a certain step depends on the number of ways to reach the previous steps.

# Approach

1. **Dynamic Programming:**  
   We can use a dynamic programming approach where we maintain an array (or two variables) to store the number of ways to reach each step.

   - Define `dp[i]` as the number of distinct ways to reach step `i`.
   - The relation is `dp[i] = dp[i - 1] + dp[i - 2]`, where:
     - `dp[i - 1]` accounts for taking a single step from `i-1`
     - `dp[i - 2]` accounts for taking a double step from `i-2`

2. **Base Cases:**

   - `dp[0] = 1` (1 way to stay at the ground)
   - `dp[1] = 1` (1 way to reach the first step)

3. Iterate from `2` to `n` to fill the `dp` array.

4. Return `dp[n]` as the result.

This approach efficiently computes the answer with minimal space.

# Complexity

- Time complexity:  
  `O(n)` – We compute the number of ways for each step up to `n`.

- Space complexity:  
  `O(1)` – We can optimize space by only storing the last two computed values instead of the entire array.

# Other Solutions

- **Recursive Approach:** A naive recursive solution can solve this problem but has exponential time complexity due to repeated calculations (similar to Fibonacci), which is inefficient for larger `n`.
- **Memoization:** We can enhance the recursive solution by storing previously computed results, which would reduce the time complexity to `O(n)` but still requires `O(n)` space.

# Pseudo Code

1. If `n == 0` or `n == 1`, return 1.
2. Initialize `first = 1` and `second = 1` (for dp[0] and dp[1]).
3. For `i` from `2` to `n`:
   - Set `current = first + second`.
   - Update `first = second` and `second = current`.
4. Return `second` (the number of ways to reach the nth step).

---

> This text is written by ChatGPT.

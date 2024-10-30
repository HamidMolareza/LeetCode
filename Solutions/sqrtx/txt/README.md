# Intuition

The task requires calculating the square root of a non-negative integer `x`, with the result truncated to the nearest integer. We can't use built-in functions like `Math.Sqrt()`, so we need to implement it ourselves. A binary search approach is ideal here since the square root value lies between `0` and `x`.

# Approach

1. Use **binary search** between `0` and `x`.
2. At each step, calculate the middle value `mid`.
3. If `mid * mid` equals `x`, return `mid` (exact square root).
4. If `mid * mid` is less than `x`, move the search to the right by setting `left = mid + 1`.
5. If `mid * mid` is greater than `x`, move the search to the left by setting `right = mid - 1`.
6. When the loop ends, the `right` pointer will contain the largest integer whose square is less than or equal to `x`.

# Complexity

- Time complexity:  
  `O(log x)` – We reduce the search space by half at each step using binary search.

- Space complexity:  
  `O(1)` – No extra space is used beyond a few variables.

# Other Solutions

- **Linear Search:** Start from 0 and increment until we find the largest integer whose square is less than or equal to `x`. However, this approach has a time complexity of `O(√x)`, making it less efficient.
- **Newton's Method:** This iterative approach converges faster than binary search but is more complex to implement and involves floating-point arithmetic.

# Pseudo Code

1. Initialize `left = 0` and `right = x`.
2. While `left <= right`:
   - Set `mid = left + (right - left) // 2`.
   - If `mid * mid == x`, return `mid`.
   - If `mid * mid < x`, set `left = mid + 1`.
   - If `mid * mid > x`, set `right = mid - 1`.
3. Return `right` (largest integer whose square is ≤ `x`).

---

> This text is written by ChatGPT.

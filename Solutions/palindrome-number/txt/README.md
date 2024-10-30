# Intuition

To determine if a number is a palindrome, we need to check if it reads the same forwards and backwards. A straightforward approach would be converting the number to a string and checking if the string is equal to its reverse. However, we can achieve this without extra space by reversing half of the number.

# Approach

We can reverse half of the number and compare it with the other half. To do this:

1. Negative numbers are not palindromes, so return false immediately for them.
2. If the last digit of the number is `0` (except for `0` itself), the number cannot be a palindrome.
3. Keep extracting the last digit and building the reversed half until the original half becomes less than or equal to the reversed half.
4. At the end, if the reversed half is equal to the original half or the original half divided by 10 (for odd-length numbers), the number is a palindrome.

This approach avoids the use of extra space, making it optimal.

# Complexity

- Time complexity:  
  `O(log_{10}(n))` – We are processing half of the digits, and the number of digits is proportional to `log_{10}(n)`.

- Space complexity:  
  `O(1)` – No extra space is used apart from a few variables.

# Other Solutions

- **String-based approach:** Convert the number to a string and compare it to its reverse. While simpler, this approach requires extra space and is not as efficient in terms of memory usage.
- **Recursive approach:** You can recursively compare digits from both ends, but recursion adds overhead and may result in stack overflow for large inputs.

# Pseudo Code

1. If `x < 0` or `(x % 10 == 0 and x != 0)`, return `false`.
2. Initialize `reversedHalf` to 0.
3. While `x > reversedHalf`:
   - Set `reversedHalf = reversedHalf * 10 + x % 10`.
   - Set `x = x // 10`.
4. Return `true` if `x == reversedHalf` or `x == reversedHalf // 10`, otherwise `false`.

---

> This text is written by ChatGPT.

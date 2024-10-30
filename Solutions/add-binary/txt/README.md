# Intuition

The problem requires adding two binary strings and returning the result as a binary string. Similar to how we add decimal numbers, binary addition also involves carrying over when the sum of two bits exceeds 1. This can be efficiently solved by iterating both strings from the end and maintaining a carry to handle overflows.

# Approach

1. Use two pointers, each starting at the end of the binary strings `a` and `b`.
2. Initialize a `carry` to 0.
3. Iterate from the end of both strings toward the beginning:
   - Sum the corresponding bits from both strings along with the carry.
   - If the sum is 2 or 3, set the current bit to `sum % 2` (0 or 1) and update the carry to `sum // 2`.
4. After processing both strings, if a carry remains, prepend it to the result.
5. Convert the result to a string and return it.

# Complexity

- Time complexity:  
  `O(max(n, m))` – where `n` and `m` are the lengths of the two binary strings. We iterate over the longer of the two.

- Space complexity:  
  `O(max(n, m))` – The result may have a length equal to the longer input string plus 1 (in case of a final carry).

# Other Solutions

- **Using built-in integer conversion:** We could convert the binary strings to integers, add them, and convert the result back to a binary string. However, this method introduces extra overhead and may not work efficiently for very large inputs.
- **Recursive solution:** We could implement the addition recursively, but this adds unnecessary stack overhead.

# Pseudo Code

1. Initialize `i = len(a) - 1` and `j = len(b) - 1`.
2. Initialize `carry = 0` and `result = []`.
3. While `i >= 0` or `j >= 0` or `carry > 0`:
   - Set `sum = carry`.
   - If `i >= 0`, add `a[i]` to `sum` and decrement `i`.
   - If `j >= 0`, add `b[j]` to `sum` and decrement `j`.
   - Append `sum % 2` to `result`.
   - Set `carry = sum // 2`.
4. Reverse `result` and join to form the binary string.
5. Return the binary string.

---

> This text is written by ChatGPT.

# Intuition

The problem involves incrementing a non-negative integer represented as an array of digits. Each element in the array corresponds to a single digit, and the most significant digit is at the start of the array. The challenge arises when the last digit is 9, which results in a carry that may propagate through multiple digits. The solution must handle cases where the entire number becomes larger (e.g., `[9,9,9]` becomes `[1,0,0,0]`).

# Approach

1. Start iterating from the last digit of the array.
2. If the current digit is less than 9, increment it and return the array, as no carry needs to propagate further.
3. If the current digit is 9, set it to 0 and continue to the next digit on the left.
4. If the loop completes and all digits were 9, prepend 1 to the array to account for the carry (e.g., `[9,9]` becomes `[1,0,0]`).

This approach ensures that we correctly handle all edge cases, including numbers that consist entirely of 9s.

# Complexity

- Time complexity:  
  `O(n)` – We may need to iterate through all the digits in the worst case.

- Space complexity:  
  `O(1)` – No extra space is used except for modifying the input array in-place (ignoring the space used for the output array).

# Other Solutions

- **Convert to Integer:** We could convert the array to an integer, increment it, and convert it back to an array. However, this introduces unnecessary overhead and potential overflow issues for very large numbers.
- **Using Recursion:** A recursive solution is possible, but it adds overhead due to function calls and isn't necessary here.

# Pseudo Code

1. Iterate from the last digit to the first:
   - If the current digit is less than 9:
     - Increment the digit and return the array.
   - If the current digit is 9:
     - Set the digit to 0 and continue to the next digit.
2. If the loop completes without returning, prepend 1 to the array.
3. Return the modified array.

---

> This text is written by ChatGPT.

# Intuition

Roman numerals use specific characters to represent numbers, with some subtractive cases (like `IV` for 4 and `IX` for 9). The challenge is to convert a Roman numeral string into an integer while handling these subtractive rules correctly. A simple approach is to traverse the string and sum the values, but we need to account for cases where smaller values precede larger ones (e.g., `IV`).

# Approach

We can iterate through the Roman numeral string from left to right. If the current character represents a smaller value than the next character (e.g., `I` followed by `V`), we subtract the current value from the total. Otherwise, we add the value to the total.  
This ensures we handle both standard and subtractive cases properly in a single pass.

We use a dictionary (hash map) to store the values of Roman numeral characters for quick lookups.

# Complexity

- Time complexity:  
  `O(n)` – We traverse the input string once, where `n` is the length of the string.

- Space complexity:  
  `O(1)` – The space required for the dictionary is constant, regardless of input size.

# Other Solutions

- **Recursive approach:** A recursive solution could traverse the string, but it adds unnecessary overhead.
- **Two-pass approach:** One could mark all subtractive cases in the first pass and compute the total in the second. However, this introduces unnecessary complexity without performance gains.

# Pseudo Code

1. Create a dictionary to map Roman numerals to their integer values:

   `roman_map = { 'I': 1, 'V': 5, 'X': 10, 'L': 50, 'C': 100, 'D': 500, 'M': 1000 }`

2. Initialize `total` to 0 and `n` to the length of the input string.
3. Iterate over the string from index `i = 0` to `n - 1`:

- If `i < n - 1` and `roman_map[s[i]] < roman_map[s[i + 1]]`:
  - Subtract `roman_map[s[i]]` from `total`.
- Else:
  - Add `roman_map[s[i]]` to `total`.

4. Return `total` as the result.

---

> This text is written by ChatGPT.

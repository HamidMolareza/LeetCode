# Intuition

The problem requires converting a Roman numeral to an integer. Roman numerals have specific rules for subtractive pairs like `IV` (4) or `IX` (9). My first thought is to traverse the string while considering these rules, ensuring we handle both additive and subtractive cases correctly.

# Approach

We iterate through the Roman numeral string from left to right:

1. If a character represents a smaller value than the next character, we subtract it (e.g., `IV` = `-1 + 5`).
2. Otherwise, we add the character’s value to the result.

To implement this, we use a dictionary to map Roman symbols to their integer values. During the traversal, if the current symbol is less than the next one, we subtract it; otherwise, we add it.

# Complexity

- Time complexity:  
  `O(n)` - We traverse the input string once, where `n` is the length of the string.

- Space complexity:  
  `O(1)` - The space used by the dictionary is constant, as there are only a limited number of Roman numerals.

# Other Solutions

Another solution could use a two-pass approach—first identifying subtractive pairs and then processing the rest of the characters. However, this would require extra logic and make the code more complex without improving performance.

> This text is written by ChatGPT.
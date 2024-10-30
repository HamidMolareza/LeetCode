# Intuition

The problem requires finding the length of the last word in a given string. A word is defined as a sequence of non-space characters. The challenge lies in handling trailing spaces that might appear at the end of the string. A straightforward way to solve this problem is to iterate backward from the end of the string, skipping any trailing spaces, and then counting the length of the last word.

# Approach

1. Start iterating from the end of the string and skip any trailing spaces.
2. Once a non-space character is found, start counting its length.
3. Stop when a space is encountered, or the beginning of the string is reached.
4. Return the length of the last word.

This approach ensures that we efficiently find the last word without needing to split the string or use extra memory.

# Complexity

- Time complexity:  
  `O(n)` – In the worst case, we iterate through the entire string.

- Space complexity:  
  `O(1)` – No extra space is used aside from a few variables.

# Other Solutions

- **Using `split` function:** We could split the string by spaces and get the last non-empty word, but this introduces additional overhead for splitting and memory usage.
- **Regular Expressions:** We could use a regex to match the last word, but it’s more complex and slower compared to a simple backward traversal.

# Pseudo Code

1. Initialize `length = 0`.
2. Start iterating from the end of the string:
   - Skip trailing spaces.
   - Once a non-space character is found, increment `length`.
   - Stop when a space is encountered, or the start of the string is reached.
3. Return `length`.

---

> This text is written by ChatGPT.

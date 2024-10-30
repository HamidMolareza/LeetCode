# Intuition

The problem requires finding the first occurrence of a substring `needle` within a larger string `haystack`. This is a classic string matching problem. A straightforward way would be to iterate over `haystack` and compare substrings of length equal to `needle`. For better performance, advanced algorithms like KMP (Knuth-Morris-Pratt) can be used, but the simpler sliding window approach suffices in many cases.

# Approach

We use a sliding window technique to compare substrings in `haystack` with `needle`. For each position in `haystack` from `0` to `len(haystack) - len(needle)`, we extract a substring of the same length as `needle` and check if it matches. If a match is found, we return the starting index. If no match is found by the end of the iteration, we return `-1`.

This approach works well for moderate input sizes.

# Complexity

- Time complexity:  
  `O(n * m)` – where `n` is the length of `haystack` and `m` is the length of `needle`. In the worst case, every character of `haystack` is compared to all characters of `needle`.

- Space complexity:  
  `O(1)` – No extra space is used aside from a few variables.

# Other Solutions

- **Knuth-Morris-Pratt (KMP) Algorithm:** This algorithm improves performance to `O(n + m)` by precomputing a prefix table. It’s more efficient for larger inputs but more complex to implement.
- **Rabin-Karp Algorithm:** Uses hashing for substring matching, but hash collisions may affect performance.

# Pseudo Code

1. If `needle` is an empty string, return 0.
2. Iterate `i` from 0 to `len(haystack) - len(needle)`:
   - If `haystack[i:i + len(needle)] == needle`, return `i`.
3. If no match is found, return `-1`.

---

> This text is written by ChatGPT.

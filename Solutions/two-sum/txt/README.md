# Intuition

The problem requires finding two numbers in the array that add up to a target value. A brute-force approach could be to try all pairs, but we can do better by leveraging a hash map (dictionary) for faster lookups.

# Approach

We iterate through the array while storing each element's value and its index in a dictionary (hash map). For every new element, we compute its complement (i.e., `target - current element`). If the complement is already in the dictionary, it means we have found the two numbers that sum up to the target. If not, we store the current element in the dictionary for future reference.

Using a hash map allows us to achieve an optimal solution in terms of time complexity since lookups and insertions in a hash map are on average `O(1)`.

# Complexity

- Time complexity:  
  `O(n)` – We traverse the list exactly once.

- Space complexity:  
  `O(n)` – In the worst case, we store all elements in the dictionary.

# Other Solutions

- **Brute-force approach:** Iterate through all pairs of elements, which has a time complexity of `O(n^2)`. This is not efficient for large inputs.
- **Sorting-based approach:** Sort the array first and then use two pointers. While it works in `O(n log n)` due to sorting, it doesn’t maintain the original index positions required by the problem.

# Pseudo Code

1. Create an empty dictionary (hash map).
2. Iterate through the array with both the element and its index.
   - Calculate the complement as `target - element`.
   - If the complement is in the dictionary, return the current index and the index of the complement.
   - Otherwise, store the element and its index in the dictionary.
3. If no solution is found, return an empty array (or throw an exception if needed).

---

> This text is written by ChatGPT.

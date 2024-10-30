# Intuition

The problem requires removing all instances of a given value `val` from the array, in-place, and returning the new length of the array. The order of elements can be changed, and we don’t need to maintain the original order. This can be efficiently solved using a two-pointer approach to overwrite the occurrences of `val`.

# Approach

We use two pointers:

1. `i` – Tracks the position where the next non-`val` element should go.
2. `j` – Iterates through the array.

We start with `i` at 0 and iterate `j` through the array. Whenever `nums[j]` is not equal to `val`, we copy `nums[j]` to `nums[i]` and increment `i`. This effectively shifts all non-`val` elements to the front of the array. After finishing the iteration, the first `i` elements will contain the valid numbers.

# Complexity

- Time complexity:  
  `O(n)` – We traverse the array once, where `n` is the length of the array.

- Space complexity:  
  `O(1)` – We do not use any extra space, only modifying the array in-place.

# Other Solutions

- **Using an additional array:** We could create a new array to store the non-`val` elements, but this requires extra space and doesn't meet the problem's constraints.
- **Recursive solution:** This could also be done recursively, but it would add unnecessary overhead and potentially lead to stack overflow on large inputs.

# Pseudo Code

1. Initialize `i` to 0.
2. Iterate `j` from 0 to the end of the array:
   - If `nums[j] != val`:
     - Set `nums[i] = nums[j]`.
     - Increment `i`.
3. Return `i` as the length of the modified array.

---

> This text is written by ChatGPT.

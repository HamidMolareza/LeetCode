# Intuition

The problem asks us to determine the index at which a target value should be inserted in a sorted array, such that the order remains correct. If the target already exists, we return its index. This can be efficiently solved using **binary search** since the array is sorted, allowing us to reduce the search space by half at every step.

# Approach

We perform a **binary search** on the sorted array:

1. Initialize two pointers: `left` to the start of the array and `right` to the end.
2. In each iteration, calculate the middle index.
3. If the value at the middle index matches the target, return the middle index.
4. If the middle value is smaller than the target, shift the search to the right half by setting `left = mid + 1`.
5. If the middle value is larger, shift the search to the left half by setting `right = mid - 1`.
6. If the target isn’t found, the `left` pointer will indicate the correct insertion position when the loop ends.

# Complexity

- Time complexity:  
  `O(log n)` – Binary search divides the search space in half at every step.

- Space complexity:  
  `O(1)` – No extra space is used.

# Other Solutions

- **Linear Search:** We could traverse the array linearly to find the target or the insertion point, but this would take `O(n)` time, making it inefficient for large arrays.
- **Recursive Binary Search:** A recursive version of binary search is also possible but introduces stack overhead and may risk stack overflow for large inputs.

# Pseudo Code

1. Initialize `left = 0` and `right = len(nums) - 1`.
2. While `left <= right`:
   - Calculate `mid = left + (right - left) // 2`.
   - If `nums[mid] == target`, return `mid`.
   - If `nums[mid] < target`, set `left = mid + 1`.
   - If `nums[mid] > target`, set `right = mid - 1`.
3. If the loop ends, return `left` as the insertion position.

---

> This text is written by ChatGPT.

# Intuition

The task is to merge two sorted arrays into a single sorted array. The first array has enough space to hold the combined elements of both arrays. This can be efficiently achieved by using a two-pointer approach, starting from the end of both arrays to avoid overwriting elements in the first array.

# Approach

1. Initialize three pointers:
   - `i` pointing to the last element of the first array (`m - 1`).
   - `j` pointing to the last element of the second array (`n - 1`).
   - `k` pointing to the last position of the merged array (`m + n - 1`).
2. While both `i` and `j` are non-negative:

   - Compare the elements at `i` and `j`.
   - Place the larger of the two elements at position `k` in the first array and decrement the respective pointer.
   - Decrement `k`.

3. If there are remaining elements in the second array (i.e., `j` is still non-negative), copy them into the first array.

4. If there are remaining elements in the first array, they are already in place.

This method ensures that we efficiently merge the two arrays without requiring additional space.

# Complexity

- Time complexity:  
  `O(m + n)` – We iterate through both arrays once.

- Space complexity:  
  `O(1)` – We perform the merge in place without using extra space for another array.

# Other Solutions

- **Using Extra Space:** We could create a new array to hold the merged values, which would simplify the merging process but require `O(m + n)` additional space.
- **Recursive Approach:** A recursive solution can be constructed, but it would not be as space-efficient as the two-pointer approach due to call stack usage.

# Pseudo Code

1. Set `i = m - 1`, `j = n - 1`, and `k = m + n - 1`.
2. While `i >= 0` and `j >= 0`:
   - If `nums1[i] > nums2[j]`:
     - Set `nums1[k] = nums1[i]`.
     - Decrement `i` and `k`.
   - Else:
     - Set `nums1[k] = nums2[j]`.
     - Decrement `j` and `k`.
3. While `j >= 0` (if there are elements left in nums2):
   - Set `nums1[k] = nums2[j]`.
   - Decrement `j` and `k`.

---

> This text is written by ChatGPT.
